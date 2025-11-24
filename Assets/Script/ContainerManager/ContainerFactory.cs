using UnityEngine;
using DG.Tweening;
using JS.Utils;

public class ContainerFactory : ManualSingletonMono<ContainerFactory>
{
    public GameObject redPrefab;
    public GameObject bluePrefab;
    public GameObject greenPrefab;
    public GameObject yellowPrefab;

    public void SpawnRed() => Spawn(redPrefab);
    public void SpawnBlue() => Spawn(bluePrefab);
    public void SpawnGreen() => Spawn(greenPrefab);
    public void SpawnYellow() => Spawn(yellowPrefab);

    private void Spawn(GameObject prefab)
    {
        Slot slot = SlotManager.Instance.GetFirstEmptySlot();
        if (slot == null) return;

        Vector3 spawnPos = slot.transform.position + Vector3.up * 3f;

        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);
        Container c = obj.GetComponent<Container>();

        obj.transform.DOMove(slot.transform.position, 0.35f)
            .SetEase(Ease.OutBack);

        slot.SetContainer(c);
    }
}
