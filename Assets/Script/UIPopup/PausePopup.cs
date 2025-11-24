using JS;
using UnityEngine;
using UnityEngine.UI;
public class PausePopup : UIBase
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        base.Awake();

        continueButton.onClick.AddListener(OnContinuePressed);
        exitButton.onClick.AddListener(OnExitPressed);
    }

    private void OnContinuePressed()
    {
        UIManager.Instance.Hide(UIName.PauseGameScreen);
        Time.timeScale = 1f;
    }

    private void OnExitPressed()
    {
        UIManager.Instance.Show(UIName.exitConfirmPopup);
    }
}
