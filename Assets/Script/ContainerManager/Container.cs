using DG.Tweening;
using UnityEngine;

public class Container : MonoBehaviour
{
    public int maxCount = 4;
    public int currentCount = 0;
    public ItemColor containerColor;
    public Slot currentSlot;

    public GameObject[] bottleSlots;

    public bool IsFull => currentCount >= maxCount;

    private void Start()
    {
        foreach (var b in bottleSlots)
            b.SetActive(false);
    }

    public void AddBottle()
    {
        if (IsFull) return;

        bottleSlots[currentCount].SetActive(true);
        currentCount++;

        if (IsFull)
        {
            currentSlot.ClearSlot();

            transform
                .DOMove(transform.position + Vector3.up * 1f, 0.35f)
                .SetEase(Ease.OutQuad);

            transform
                .DOScale(Vector3.zero, 0.35f)
                .SetEase(Ease.InBack)
                .OnComplete(() =>
                {
                    Destroy(gameObject);
                });
        }
    }

    public void PlayDestroyAnimation()
    {
        transform
            .DOMove(transform.position + Vector3.up * 1f, 0.35f)
            .SetEase(Ease.OutQuad);

        transform
            .DOScale(Vector3.zero, 0.35f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
}
