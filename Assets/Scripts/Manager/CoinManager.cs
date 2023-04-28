using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public int coin = 300;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        coinText.text = "" + coin;
    }

    public bool BuyItem(int price)
    {
        if (coin - price >= 0)
        {
            coin = coin - price;
            coinText.text =""+ coin;
            return true;
        }
        else
        {
            return false;
        }
       
    }
    public void SellItem(int price)
    {
            coin = coin + price;
            coinText.text = "" + coin;
    }
}
