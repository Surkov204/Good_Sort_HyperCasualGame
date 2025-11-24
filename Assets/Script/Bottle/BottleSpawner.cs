using UnityEngine;
using DG.Tweening;
using JS.Utils;
using System.Collections;
public class BottleSpawner : ManualSingletonMono<BottleSpawner>
{
    public GameObject bottlePrefab;
    public Transform spawnPoint;  
    public Transform endPoint;     

    public float speed = 2.0f;

    private void Start()
    {
        StartCoroutine(AutoSpawnLoop());
    }

    IEnumerator AutoSpawnLoop()
    {
        while (true)
        {
            SpawnBottle(GetRandomColor());
            yield return new WaitForSeconds(0.8f);
        }
    }

    ItemColor GetRandomColor()
    {
        int r = Random.Range(0, 4);
        return (ItemColor)r;
    }

    public void SpawnBottle(ItemColor color)
    {
        GameObject obj = Instantiate(bottlePrefab, spawnPoint.position, Quaternion.identity);
        Bottle bottle = obj.GetComponent<Bottle>();
        bottle.SetColor(color);

        obj.transform.DOMove(endPoint.position, speed)
            .SetEase(Ease.Linear)
            .OnComplete(() => Destroy(obj));
    }
}
