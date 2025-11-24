using UnityEngine;
using TMPro;
using DG.Tweening;

public class LevelPopupController : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelTextInformation;

    void Start()
    {
        if (!levelTextInformation.gameObject.activeInHierarchy) levelText.gameObject.SetActive(true);
        ShowlevelInfor(LevelManager.Instance.GetCurrentLevel());
        if (!levelText.gameObject.activeInHierarchy) levelText.gameObject.SetActive(true);
        DOVirtual.DelayedCall(1f, () =>
        {
            ShowLevel(LevelManager.Instance.GetCurrentLevel());
        });
    }

    public void ShowlevelInfor(int level){
        levelTextInformation.text = "LEVEL " + level;
    }

    public void ShowLevel(int level)
    {
        levelText.text = "LEVEL " + level;
            
        levelText.transform.localScale = Vector3.zero;
        levelText.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(levelText.transform.DOScale(1.4f, 0.4f)
            .SetEase(Ease.OutBack));    // Bật to cute

        seq.Append(levelText.transform.DOScale(1.0f, 0.25f)
            .SetEase(Ease.InOutSine));  // Nhún nhẹ

        seq.AppendInterval(0.5f);       // Đứng im 1 chút

        seq.Append(levelText.DOFade(0f, 0.4f));  // Mờ dần rồi biến mất

        seq.OnComplete(() =>
        {
            levelText.gameObject.SetActive(false);
            levelText.color = new Color(levelText.color.r, levelText.color.g, levelText.color.b, 1f);
        });
    }
}
