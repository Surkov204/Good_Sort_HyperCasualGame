using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using DG.Tweening;
using JS.Utils;
using Random = UnityEngine.Random;
using Action = System.Action;

public class BottleLineManager : ManualSingletonMono<BottleLineManager>
{
    [Header("Spline đường đi của chai")]
    public SplineContainer spline;

    [Header("Prefab chai")]
    public GameObject bottlePrefab;

    [Header("Số chai muốn spawn (base)")]
    public int bottleCount = 20;

    public List<Bottle> bottles = new List<Bottle>();
    private List<Vector3> positions = new List<Vector3>();

    public static event Action OnWinEvent;

    void Start()
    {
        // Load level hiện tại
        int level = PlayerPrefs.GetInt("LEVEL", 1);

        // Tính toán số chai theo level
        bottleCount = GetBottleCountForLevel(level);

        // Tạo vị trí theo spline
        GeneratePositionsFromSpline();

        // Spawn dãy màu có độ khó theo level
        SpawnInitialBottles(level);
    }

    //=============================
    //       TÍNH SỐ CHAI THEO LEVEL
    //=============================
    public int GetBottleCountForLevel(int level)
    {
        // Level càng cao → càng nhiều chai
        // Level 1 → 10 chai
        // Level 10 → 28 chai
        // Level 20 → 48 chai
        return Mathf.Clamp(50 + (level - 1) * 2, 70, 100);
    }

    //=============================
    //      TẠO VỊ TRÍ SPLINE
    //=============================
    void GeneratePositionsFromSpline()
    {
        positions.Clear();

        for (int i = 0; i < bottleCount; i++)
        {
            float t = (float)i / (bottleCount - 1);
            positions.Add(spline.EvaluatePosition(t));
        }
    }

    //=============================
    //      SPAWN THEO LEVEL
    //=============================
    void SpawnInitialBottles(int level)
    {
        bottles.Clear();

        // Lấy pattern màu theo level
        ItemColor[] colors = BottleLineGenerator.GenerateLine(level, bottleCount);

        for (int i = 0; i < positions.Count; i++)
        {
            SpawnBottleAt(i, colors[i]);
        }
    }

    void SpawnBottleAt(int index, ItemColor color)
    {
        GameObject obj = Instantiate(bottlePrefab, positions[index], Quaternion.identity);
        Bottle b = obj.GetComponent<Bottle>();
        b.SetColor(color);
        bottles.Add(b);
    }

    //=============================
    //      REMOVE & SHIFT
    //=============================
    public void RemoveBottle(Bottle b)
    {
        if (!bottles.Contains(b)) return;

        bottles.Remove(b);
        Destroy(b.gameObject);

        if (bottles.Count == 0)
        {
            Debug.Log("WIN DETECTED → BẮN EVENT");
            OnWinEvent?.Invoke();
        }

        MoveForward();
    }

    void MoveForward()
    {
        for (int i = 0; i < bottles.Count; i++)
        {
            bottles[i].transform.DOMove(positions[i], 0.25f)
                .SetEase(Ease.OutQuad);
        }
    }

    public Bottle GetFirstBottle()
    {
        if (bottles.Count == 0) return null;
        return bottles[0];
    }
}
