using UnityEngine;

public class Slot : MonoBehaviour
{
    public Container container;

    public bool HasContainer => container != null;

    public void SetContainer(Container c)
    {
        container = c;
        c.currentSlot = this;
    }

    public void ClearSlot()
    {
        container = null;
    }

}
