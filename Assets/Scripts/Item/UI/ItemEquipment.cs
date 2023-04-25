using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipment : Item
{
    public override void Start()
    {
        itemButton.gameObject.SetActive(false);
    }
    public void IsRemove()
    {
        itemButton.gameObject.SetActive(false);
        itemImage.sprite = null;
   
        if (itemMode == itemMode.Hat)
        {
            itemTextMeshPro.text = "No Hat";
        }
        else if (itemMode == itemMode.Weapon)
        {
            itemTextMeshPro.text = "No Weapon";
        }

    }
    public void IsAdd(string id_,Sprite sprite,string text)
    {
        id = id_;
        itemImage.sprite = sprite;
        itemTextMeshPro.text = text;
        itemButton.gameObject.SetActive(true);
    }
}
