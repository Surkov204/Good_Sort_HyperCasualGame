using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private int currentLevel;

    private void Awake()
    {
        // Tạo singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Load level ở Awake luôn, tránh null bên BottleLineManager
        currentLevel = PlayerPrefs.GetInt("LEVEL", 1);
        Debug.Log("LevelManager Awake – CurrentLevel = " + currentLevel);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void ProgressToNextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("LEVEL", currentLevel);
        Debug.Log("LEVEL UP → " + currentLevel);
    }
}
