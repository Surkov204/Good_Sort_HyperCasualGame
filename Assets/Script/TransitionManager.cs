using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionManager : MonoBehaviour
{
    public RectTransform circle;   
    public float irisDuration = 0.6f;

    private void Awake()
    {
        TestIrisIn();
    }

    public void TestIrisOut()
    {
        circle.localScale = Vector3.zero;

        circle.DOScale(20f, irisDuration)
              .SetEase(Ease.InOutQuad);
    }

    public void TestIrisIn()
    {
        circle.localScale = Vector3.one * 20f;

        circle.DOScale(0f, irisDuration)
              .SetEase(Ease.InOutQuad);
    }
}