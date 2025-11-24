using System;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    public int maxLife = 5;
    public int currentLife;

    private const string LIFE_KEY = "life_current";
    private const string LAST_LOST_KEY = "life_lastLostTime";

    public float restoreTime = 60f; // 1 phút = 60 giây

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        LoadLife();
        RestoreLifeIfOffline();
    }

    // ============================================
    // ========== LIFE RESTORE SYSTEM =============
    // ============================================

    void LoadLife()
    {
        if (!PlayerPrefs.HasKey(LIFE_KEY))
        {
            currentLife = maxLife;
            PlayerPrefs.SetInt(LIFE_KEY, currentLife);
        }
        else
        {
            currentLife = PlayerPrefs.GetInt(LIFE_KEY);
        }
    }

    /// <summary>
    /// Khi người chơi quay lại sau khi đóng game → hồi life theo thời gian thực
    /// </summary>
    void RestoreLifeIfOffline()
    {
        if (currentLife >= maxLife) return;

        if (!PlayerPrefs.HasKey(LAST_LOST_KEY)) return;

        long lastTime = long.Parse(PlayerPrefs.GetString(LAST_LOST_KEY));
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        long passed = now - lastTime;

        int restored = (int)(passed / restoreTime);

        if (restored > 0)
        {
            currentLife = Mathf.Min(maxLife, currentLife + restored);
            PlayerPrefs.SetInt(LIFE_KEY, currentLife);

            // update last lost time (nếu vẫn chưa max)
            if (currentLife < maxLife)
            {
                long remain = passed % (long)restoreTime;
                long newTime = now - remain;
                PlayerPrefs.SetString(LAST_LOST_KEY, newTime.ToString());
            }
        }
    }

    // ============================================
    // ========== PUBLIC ACTION METHODS ============
    // ============================================

    public void LoseLife()
    {
        if (currentLife <= 0) return;

        currentLife--;
        PlayerPrefs.SetInt(LIFE_KEY, currentLife);

        // nếu mất mạng → lưu timestamp
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        PlayerPrefs.SetString(LAST_LOST_KEY, now.ToString());
    }

    public bool HasLife()
    {
        return currentLife > 0;
    }

    public float GetTimeToNextLife()
    {
        if (currentLife >= maxLife) return 0;

        long last = long.Parse(PlayerPrefs.GetString(LAST_LOST_KEY));
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        float remain = restoreTime - (now - last);
        return Mathf.Max(remain, 0);
    }

    public void AddLife(int amount)
    {
        currentLife = Mathf.Min(maxLife, currentLife + amount);
        PlayerPrefs.SetInt(LIFE_KEY, currentLife);

        if (currentLife >= maxLife)
        {
            PlayerPrefs.DeleteKey(LAST_LOST_KEY);
        }
    }

}
