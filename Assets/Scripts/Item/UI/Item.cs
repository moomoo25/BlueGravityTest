using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item : MonoBehaviour
{
    public string id;
    public TextMeshProUGUI itemTextMeshPro;
    public Image itemImage;
    public bool isValue;
    public int number;
    public TextMeshProUGUI valueTextMeshPro;
    public Button itemButton;
    public int sellPrice;
    public int buyPrice;
    public itemMode itemMode;
    public virtual void Start()
    {
        itemButton.onClick.AddListener(OnClickItemButton);
    }
    public virtual void OnClickItemButton()
    {

    }
    public virtual void SetUpItemDetail(string id_,Sprite sprite,string detail,bool isValue,int n, itemMode itemMode_,int sellPrice_,int buyPrice_)
    {
        id = id_;
        itemImage.sprite = sprite;
        itemTextMeshPro.text = detail;
        sellPrice = sellPrice_;
        buyPrice = buyPrice_;
        itemMode = itemMode_;
        if (isValue == false)
        {
            valueTextMeshPro.gameObject.SetActive(false);
            return;
        }



        itemButton.gameObject.SetActive(false);
        valueTextMeshPro.text = "" + n;
    }

}
