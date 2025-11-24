using JS;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverScreen : UIBase
{
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        base.Awake();
        restartButton.onClick?.AddListener(OnRestartPressed);
    }

    private void OnRestartPressed()
    {
        if (LifeManager.Instance.currentLife <= 0)
        {
            UIManager.Instance.Show(JS.UIName.lifePopup);
            return;
        }

        MaskTransitions.TransitionManager.Instance
            .LoadSceneWithTransition("MainGamePlay");
    }
}
