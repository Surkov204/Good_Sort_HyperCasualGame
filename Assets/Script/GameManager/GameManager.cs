using UnityEngine;
using JS.Utils;
using System;

public class GameManager : ManualSingletonMono<GameManager>
{
    public bool IsGameOver = false;
    public static event Action OnWinEvent;
    public static event Action OnGameOverEvent;

    void Start()
    {
        GameTimer.Instance.StartTimer();
    }

    private void OnEnable()
    {
        BottleManager.OnGameOverEvent += HandleGameOver;
        BottleLineManager.OnWinEvent += HandleWin;
       
    }

    private void OnDisable()
    {
        BottleManager.OnGameOverEvent -= HandleGameOver;
        BottleLineManager.OnWinEvent -= HandleWin;
    }

    private void HandleWin()
    {
        if (IsGameOver) return;

        Debug.Log("YOU WIN!");
        IsGameOver = true;
        float time = GameTimer.Instance.playTime;
        int reward = RewardCalculator.CalculateReward(time);

        GoldManager.Instance.AddGold(reward);

        SlotManager.Instance.ClearAllContainersWithAnimation();
        WinAnimationController.Instance.PlayWinSequence();
    }

    private void HandleGameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;

        Debug.Log("GAME OVER by event!");
        LifeManager.Instance.LoseLife();
        UIManager.Instance.Show(JS.UIName.GameOverScreen);
    }

    public void PauseGame() 
    {
        UIManager.Instance.Show(JS.UIName.PauseGameScreen);
    }

    public void GameOver()
    {
        IsGameOver = true;
        Debug.Log("game over");
    }
}
