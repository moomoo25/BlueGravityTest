using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCharacter : Item
{
 
    public override void OnClickItemButton()
    {
        GameManager.singleton.EquipItem(itemObject);
        Destroy(this.gameObject);
 
    }
}
