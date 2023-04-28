using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCharacter : Item
{
    public override void Start()
    {
        base.Start();

        if (itemObject.isValue)
        {
            GetItemButtonText().text = "Consume";
        }
        else
        {
            GetItemButtonText().text = "Equip";
        }
    }
    public override void OnClickItemButton()
    {
        if (!itemObject.isValue)
        {
            GameManager.singleton.EquipItem(itemObject);
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.singleton.ConsumeItem(itemObject);
            if (itemObject.isValue)
            {
                int a = itemObject.value;
                if (a >= 0)
                {
                    return;
                }
            }
            Destroy(this.gameObject);
        }

     
    }
}

