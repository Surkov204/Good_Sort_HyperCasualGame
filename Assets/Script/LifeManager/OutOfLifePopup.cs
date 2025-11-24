using UnityEngine;
using TMPro;
using System;

public class OutOfLifePopup : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private void Update()
    {
        float remain = LifeManager.Instance.GetTimeToNextLife();
        TimeSpan t = TimeSpan.FromSeconds(remain);

        timerText.text = $"Next life in {t.Minutes:D2}:{t.Seconds:D2}";
    }
}
