using UnityEngine;

public class Bottle : MonoBehaviour
{
    public ItemColor color;

    public MeshRenderer bodyRenderer;
    public bool hasBeenChecked = false;

    public void SetColor(ItemColor c)
    {
        color = c;
        hasBeenChecked = false;
        switch (color)
        {
            case ItemColor.Red:
                bodyRenderer.material.color = Color.red;
                break;

            case ItemColor.Green:
                bodyRenderer.material.color = Color.green;
                break;

            case ItemColor.Blue:
                bodyRenderer.material.color = Color.blue;
                break;

            case ItemColor.Yellow:
                bodyRenderer.material.color = Color.yellow;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || other.gameObject == null)
        {
            Debug.LogError("OTHER IS NULL!");
            return;
        }

        if (!other.CompareTag("CheckZone"))
        {
            return;
        }

        Debug.Log("Bottle hit CheckZone: " + color);

        if (BottleManager.Instance == null)
        {
            Debug.LogError("BottleManager INSTANCE NULL!");
            return;
        }

        BottleManager.Instance.OnBottleEnterCheckZone(this);
    }
}
