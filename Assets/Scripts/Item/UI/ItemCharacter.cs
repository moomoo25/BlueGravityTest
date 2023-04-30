using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCharacter : Item
{
    public override void Start()
    {
        base.Start();

        if (itemObject.itemMode == itemMode.Consumer)
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
        if (itemObject.itemMode != itemMode.Consumer)
        {
            GameManager.singleton.EquipItem(itemObject);
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.singleton.ConsumeItem(itemObject);

            if (itemObject.itemMode == itemMode.Consumer)
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

