using System;
using UnityEngine;
using JS.Utils;
using DG.Tweening;

public class BottleManager : ManualSingletonMono<BottleManager>
{
    public static event Action OnGameOverEvent;

    public void OnBottleEnterCheckZone(Bottle bottle)
    {
        if (TryPutBottleIntoCorrectContainer(bottle))
            return;

        if (SlotManager.Instance.HasEmptySlot())
        {
            return;
        }
        OnGameOverEvent?.Invoke();
    }

    private bool TryPutBottleIntoCorrectContainer(Bottle bottle)
    {
        foreach (var slot in SlotManager.Instance.slots)
        {
            if (!slot.HasContainer)
                continue;

            Container c = slot.container;

            if (c.containerColor == bottle.color)
            {
                if (c.IsFull)
                {                
                    GameManager.Instance.GameOver();
                    return true;
                }

                PutBottleIntoContainer(bottle, c);
                return true;
            }
        }

        return false;
    }

    private void PutBottleIntoContainer(Bottle bottle, Container container)
    {
        bottle.transform.DOMove(container.transform.position, 0.25f)
        .SetEase(Ease.OutQuad)
        .OnComplete(() =>
        {
            container.AddBottle();
            BottleLineManager.Instance.RemoveBottle(bottle);
            Destroy(bottle.gameObject);
        });

    }
}
