using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemShop : Item
{
    public bool isBuySlot;
    public Color green;
    public Color red;
    public TextMeshProUGUI priceText;
    void Awake()
    {
        SetUpBuyButton();
    }
    public void SetUpBuyButton()
    {
        if (isBuySlot)
        {
            itemButton.GetComponent<Image>().color = green;
            priceText.text = "Price: " + itemObject.buyPrice;
            itemButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
            valueTextMeshPro.gameObject.SetActive(false);
        }
        else
        {
            itemButton.GetComponent<Image>().color = red;
            priceText.text = "Price: " + itemObject.sellPrice;
            itemButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell";
         
        }
    }
    public override void SetUpItemDetail(ItemObject itemObject_)
    {
        base.SetUpItemDetail(itemObject_);
        SetUpBuyButton();
    }
    public override void OnClickItemButton()
    {

        if (isBuySlot)
        {
            GameManager.singleton.BuyItem(itemObject);
                if (itemObject.isBuyOnce)
                    Destroy(this.gameObject);
        }
        else
        {
            GameManager.singleton.SellItem(itemObject);
            if (itemObject.isValue)
            {
               
                int a = itemObject.value;
                if ( a >= 0)
                {
                    return;
                }

            }
            Destroy(this.gameObject);
        }
           

        
    }
 
}
