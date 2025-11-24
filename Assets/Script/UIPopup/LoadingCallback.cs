using UnityEngine;

public class LoadingCallbackReceiver : MonoBehaviour
{
    public static System.Action OnLoadingDone;

    public void NotifyLoaded()
    {
        OnLoadingDone?.Invoke();
        OnLoadingDone = null;
    }
}