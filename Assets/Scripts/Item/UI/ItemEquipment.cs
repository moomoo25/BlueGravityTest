using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipment : Item
{
    public override void Start()
    {
        itemButton.gameObject.SetActive(false);
        itemButton.onClick.AddListener(OnClickItemButton);
    }
    public void IsRemove()
    {
        itemButton.gameObject.SetActive(false);
        itemImage.sprite = null;
   
        if (itemObject.itemMode == itemMode.Hat)
        {
            itemTextMeshPro.text = "No Hat";
        }
        else if (itemObject.itemMode == itemMode.Weapon)
        {
            itemTextMeshPro.text = "No Weapon";
        }
        
    }
    public override void OnClickItemButton()
    {
        GameManager.singleton.RemoveEquipItem(itemObject.itemMode);
        IsRemove();
      
    }
    public void IsAdd(ItemObject itemObject_)
    {
        itemObject = itemObject_;
        itemImage.sprite = itemObject_.itemImage;
        itemTextMeshPro.text = itemObject_.itemText;
        itemButton.gameObject.SetActive(true);
        itemObject.sellPrice = itemObject_.sellPrice;
    }
}
