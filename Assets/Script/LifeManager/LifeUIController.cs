using UnityEngine;
using TMPro;
using System;

public class LifeUIController : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI timerText;

    private void Update()
    {
        lifeText.text = LifeManager.Instance.currentLife + "/5";

        if (LifeManager.Instance.currentLife < LifeManager.Instance.maxLife)
        {
            float remain = LifeManager.Instance.GetTimeToNextLife();
            TimeSpan t = TimeSpan.FromSeconds(remain);
            timerText.text = $"{t.Minutes:D2}:{t.Seconds:D2}";
        }
        else
        {
            timerText.text = "";
        }
    }
}
