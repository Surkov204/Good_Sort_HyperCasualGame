using UnityEngine;

public class SceneTransitionBridge : MonoBehaviour
{
    public void PlayStartTransitionThenLoad(string sceneName)
    {
        // Play iris-out
        MaskTransitions.TransitionManager.Instance.PlayStartHalfTransition(
         MaskTransitions.TransitionManager.Instance.transitionTime
        );

        // Delay đúng thời gian transition trước khi load scene
        Invoke(nameof(LoadDelayed), MaskTransitions.TransitionManager.Instance.transitionTime);

        targetScene = sceneName;
    }

    private string targetScene;

    private void LoadDelayed()
    {
        SceneLoader.Load(targetScene);
    }
}