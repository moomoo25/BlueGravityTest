using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCharacter : Item
{
 
    public override void OnClickItemButton()
    {
        if (itemMode == itemMode.Hat)
        {
            GameManager.singleton.EquipHat(id,itemImage.sprite,itemTextMeshPro.text);
        }
        else if (itemMode == itemMode.Weapon)
        {
            GameManager.singleton.EquipWeapon(id,itemImage.sprite, itemTextMeshPro.text);
        }
        Destroy(this.gameObject);
 
    }
}
