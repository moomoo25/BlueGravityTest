using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCharacter : Item
{
 
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

        if (itemMode == itemMode.Hat)
        {
            GameManager.singleton.EquipHat(itemObject);
        }
        else if (itemMode == itemMode.Weapon)
        {
            GameManager.singleton.EquipWeapon(itemObject);
        }
        Destroy(this.gameObject);
 
    }
}
