using UnityEngine;
using TMPro;

public class GameplayTimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Update()
    {
        float t = GameTimer.Instance.playTime;

        int minutes = Mathf.FloorToInt(t / 60f);
        int seconds = Mathf.FloorToInt(t % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
