using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance;

    public int gold = 0;

    private const string KEY_GOLD = "PLAYER_GOLD";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            gold = PlayerPrefs.GetInt(KEY_GOLD, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Save();
    }

    public bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            Save();
            return true;
        }

        return false;
    }

    private void Save()
    {
        PlayerPrefs.SetInt(KEY_GOLD, gold);
        PlayerPrefs.Save();
    }
}
