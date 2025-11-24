using JS;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPopupLife : UIBase
{
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        base.Awake();
        restartButton.onClick?.AddListener(AcceptRequirement);
    }

    private void AcceptRequirement()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MainMenu")
        {
            UIManager.Instance.Hide(JS.UIName.lifePopup);
            return;
        }

        if (currentScene == "MainGamePlay")
        {
            UIManager.Instance.Hide(JS.UIName.lifePopup);
            MaskTransitions.TransitionManager.Instance.LoadSceneWithTransition("MainMenu");
        }
    }
}
