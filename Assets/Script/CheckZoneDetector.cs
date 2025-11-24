using UnityEngine;

public class CheckZoneDetector : MonoBehaviour
{
    public Vector3 size = new Vector3(2, 2, 2);
    public LayerMask bottleLayer;

    [Header("Light Indicator")]
    public Light indicatorLight;
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;

    private void Start()
    {
        if (indicatorLight != null)
            indicatorLight.color = incorrectColor; 
    }

    private void Update()
    {
        if (!SlotManager.Instance.HasAnyContainer())
            return;

        // Nếu tất cả thùng đều full → dừng check
        if (SlotManager.Instance.AreAllContainersFull())
            return;

        Collider[] hits = Physics.OverlapBox(
            transform.position,
            size * 0.5f,
            Quaternion.identity,
            bottleLayer
        );

        if (hits.Length == 0)
        {
            indicatorLight.color = correctColor; // không có chai → xanh
            return;
        }

        foreach (var h in hits)
        {
            Bottle bottle = h.GetComponent<Bottle>();

            if (bottle == null) continue;

            // Tìm container đang chờ nhận chai
            Slot targetSlot = SlotManager.Instance.GetMatchableSlot(bottle.color);

            if (targetSlot == null)
            {
                // ❌ Không có slot khớp màu → ĐÈN ĐỎ
                indicatorLight.color = incorrectColor;
            }
            else
            {
                // ✔️ Có slot khớp màu → ĐÈN XANH
                indicatorLight.color = correctColor;
            }

            // Gửi xử lý chai
            BottleManager.Instance.OnBottleEnterCheckZone(bottle);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
