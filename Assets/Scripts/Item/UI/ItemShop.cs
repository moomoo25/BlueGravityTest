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
            priceText.text = "Price:" + itemObject.buyPrice;
            itemButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
        }
        else
        {
            itemButton.GetComponent<Image>().color = red;
            priceText.text = "Price:" + itemObject.sellPrice;
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
            //this.id = ""+ Random.Range(0, 100000);
        }
        else
        {
            GameManager.singleton.SellItem(itemObject.id,itemObject.sellPrice);
            Destroy(this.gameObject);
        }
           

        
    }
 
}
