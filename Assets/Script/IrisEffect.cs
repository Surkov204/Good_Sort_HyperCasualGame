using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IrisEffect : MonoBehaviour
{

    public RectTransform irisCircle;
    public float duration = 1.0f;

    private void Awake()
    {
        StartIrisOut();
    }

    public void StartIrisOut()
    {
        irisCircle.localScale = Vector3.one * 10f; 
        StartCoroutine(AnimateIrisOut());
    }

    private IEnumerator AnimateIrisOut()
    {
        float timer = 0f;
        Vector3 startScale = irisCircle.localScale;
        Vector3 targetScale = Vector3.zero; 

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            t = t * t * (3f - 2f * t);

            irisCircle.localScale = Vector3.Lerp(startScale, targetScale, t);

            yield return null;
        }

        irisCircle.localScale = targetScale;

        Debug.Log("Iris Out hoàn thành! Sẵn sàng chuyển cảnh.");
    }
}