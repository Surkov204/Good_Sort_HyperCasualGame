using UnityEngine;

public class RewardCalculator : MonoBehaviour
{
    public static int CalculateReward(float playTimeSeconds)
    {
        if (playTimeSeconds < 60f)
            return 10;     
        else if (playTimeSeconds < 120f)
            return 5;      
        else
            return 3;     
    }
}
