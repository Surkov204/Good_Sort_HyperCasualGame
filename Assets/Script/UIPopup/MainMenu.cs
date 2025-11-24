using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string GameScene;

    public void OnPlayPressed()
    {
        if (!LifeManager.Instance.HasLife())
        {
            UIManager.Instance.Show(JS.UIName.lifePopup);
            return;
        }
        MaskTransitions.TransitionManager.Instance.LoadSceneWithTransition(GameScene);
    }

    public void OnPressShop()
    {
        UIManager.Instance.Show(JS.UIName.ShopPopup);
    }

    public void OnSettingPress() {
        UIManager.Instance.Show(JS.UIName.GameSettingScreen);
    }

    public void OnHomePress() {
        if (UIManager.Instance.IsVisible(JS.UIName.ShopPopup)) UIManager.Instance.Hide(JS.UIName.ShopPopup);
    }
}
