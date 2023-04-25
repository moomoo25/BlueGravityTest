using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemShop : Item
{
    public bool isBuy;
    public Color green;
    public Color red;
    public TextMeshProUGUI priceText;
    void Awake()
    {
        SetUpBuyButton();
    }
    public void SetUpBuyButton()
    {
        if (isBuy)
        {
            itemButton.GetComponent<Image>().color = green;
            priceText.text = "Price:" + buyPrice;
            itemButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
        }
        else
        {
            itemButton.GetComponent<Image>().color = red;
            priceText.text = "Price:" + sellPrice;
            itemButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell";
        }
    }
    public override void OnClickItemButton()
    {
        ItemObject itemObject = new ItemObject();
        itemObject.id = id;
        itemObject.itemImage = itemImage.sprite;
        itemObject.itemText = itemTextMeshPro.text;
        itemObject.isValue = isValue;
        itemObject.value = number;
        itemObject.sellPrice = sellPrice;
        itemObject.buyPrice = buyPrice;
        itemObject.itemMode = itemMode;

        if (isBuy)
        {
            GameManager.singleton.BuyItem(itemObject);
        }
        else
        {
            GameManager.singleton.SellItem(itemObject.id,itemObject.sellPrice);
        }
           

        Destroy(this.gameObject);
    }
 
}
