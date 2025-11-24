using UnityEngine;
using DG.Tweening;
using JS.Utils;

public class WinAnimationController : ManualSingletonMono<WinAnimationController>
{
    public RectTransform uiButtonsPanel;
    public Transform car;

    public float uiHideOffsetY = -600f;
    public float uiHideDuration = 0.5f;

    public float carMoveDuration = 1f;
    public float carTargetX = 0f;  

    public void PlayWinSequence()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(uiButtonsPanel.DOAnchorPosY(uiHideOffsetY, uiHideDuration)
            .SetEase(Ease.InBack));

        seq.AppendInterval(0.2f);

        seq.Append(car.DOMoveX(carTargetX, carMoveDuration)
            .SetEase(Ease.OutExpo));

        seq.AppendCallback(ShowWinnerPanel);
    }

    private void ShowWinnerPanel()
    {
        UIManager.Instance.Show(JS.UIName.WinnerGamePopup);
        LevelManager.Instance.ProgressToNextLevel();
    }
}