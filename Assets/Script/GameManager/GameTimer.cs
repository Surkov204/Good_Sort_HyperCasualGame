using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    public float playTime = 0f;
    private bool isRunning = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (isRunning)
            playTime += Time.deltaTime;
    }

    public void StartTimer()
    {
        playTime = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
