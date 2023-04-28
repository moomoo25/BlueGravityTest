using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemTextMeshPro;
    public TextMeshProUGUI valueTextMeshPro;
    public Button itemButton;
    public ItemObject itemObject;
    public virtual void Start()
    {
        itemButton.onClick.AddListener(OnClickItemButton);
    }
  
    public virtual void OnClickItemButton()
    {

    }
    public virtual void SetUpItemDetail(ItemObject itemObject_)
    {
        itemObject.id = itemObject_.id;
        itemObject.itemId = itemObject_.itemId;
        itemImage.sprite = itemObject_.itemImage;
        itemTextMeshPro.text = itemObject_.itemText;
        itemObject.itemImage = itemObject_.itemImage;
        itemObject.itemText = itemObject_.itemText;
        itemObject.sellPrice = itemObject_.sellPrice;
        itemObject.buyPrice = itemObject_.buyPrice;
        itemObject.itemMode = itemObject_.itemMode;
        itemObject.isBuyOnce = itemObject_.isBuyOnce;

        if (itemObject_.isValue == false)
        {
            valueTextMeshPro.gameObject.SetActive(false);
            return;
        }

        itemButton.gameObject.SetActive(false);
        valueTextMeshPro.text = "" + itemObject_.value;
    }

}
