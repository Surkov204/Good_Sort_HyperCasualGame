using UnityEngine;

public class DevTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spawn Test!");
            BottleSpawner.Instance.SpawnBottle(ItemColor.Red);
        }
    }
}
