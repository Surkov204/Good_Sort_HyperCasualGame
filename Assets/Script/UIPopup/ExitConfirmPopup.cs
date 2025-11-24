using JS;
using UnityEngine;
using UnityEngine.UI;

public class ExitConfirmPopup : UIBase
{
    [SerializeField] private Button okButton;
    [SerializeField] private Button cancelButton;

    private void Awake()
    {
        base.Awake();

        okButton.onClick.AddListener(OnOK);
        cancelButton.onClick.AddListener(OnCancel);
    }

    private void OnOK()
    {
        LifeManager.Instance.LoseLife();

        UIManager.Instance.Hide(UIName.exitConfirmPopup);
        UIManager.Instance.Hide(UIName.PauseGameScreen);

        MaskTransitions.TransitionManager.Instance.LoadSceneWithTransition("MainMenu");
    }

    private void OnCancel()
    {
        UIManager.Instance.Hide(UIName.exitConfirmPopup);
    }
}
