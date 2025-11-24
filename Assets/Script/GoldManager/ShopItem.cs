using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public int price;
    public int lifeToAdd;
    public TextMeshProUGUI priceText;

    private void Start()
    {
        priceText.text = price + " GOLD";
    }

    public void OnBuy()
    {
        if (GoldManager.Instance.SpendGold(price))
        {
            LifeManager.Instance.AddLife(lifeToAdd);
            Debug.Log("Bought + " + lifeToAdd + " life");
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }
}
