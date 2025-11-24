using UnityEngine;
using JS.Utils;

public class SlotManager : ManualSingletonMono<SlotManager>
{
    public Slot[] slots;

    public Slot GetFirstEmptySlot()
    {
        foreach (var slot in slots)
            if (!slot.HasContainer)
                return slot;

        return null;
    }

    public bool HasEmptySlot()
    {
        foreach (var slot in slots)
            if (!slot.HasContainer)
                return true;

        return false;
    }

    public Slot GetMatchableSlot(ItemColor bottleColor)
    {
        foreach (var slot in slots)
        {
            if (!slot.HasContainer) continue;

            Container c = slot.container;

            if (c.containerColor == bottleColor && !c.IsFull)
                return slot;
        }

        return null;
    }

    public bool HasAnyContainer()
    {
        foreach (var slot in slots)
            if (slot.HasContainer)
                return true;

        return false;
    }

    public bool AreAllContainersFull()
    {
        foreach (var slot in slots)
        {
            if (!slot.HasContainer) return false;
            if (!slot.container.IsFull) return false;
        }

        return true;
    }

    public void ClearAllContainersWithAnimation()
    {
        foreach (var slot in slots)
        {
            if (!slot.HasContainer) continue;

            Container c = slot.container;
            if (c != null)
            {
                c.PlayDestroyAnimation();
            }
        }
    }
}
