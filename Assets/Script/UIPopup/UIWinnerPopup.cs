using JS;
using UnityEngine;
using UnityEngine.UI;

public class UIWinnerPopup : UIBase
{
    [SerializeField] private Button homeButton;
    //  [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        base.Awake();
        homeButton.onClick?.AddListener(HomeButton);
        //  mainMenuButton.onClick?.AddListener(BackToMainMenu);
    }

    private void HomeButton()
    {
        MaskTransitions.TransitionManager.Instance.LoadSceneWithTransition("MainMenu");
        //  ScoreManager.Instance.ResetScore();
    }

    private void BackToMainMenu()
    {
        //SceneLoader.Load("MainMenu");
    }
}
