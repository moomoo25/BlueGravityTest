using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemDetailScriptableObject", order = 1)]
public class ItemDetailScriptableObject : ScriptableObject
{
    public ItemObjectData[] itemObjectData;
    public ItemObject GetItemById(string itemId)
    {
        ItemObject itemObject = new ItemObject();
        for (int i = 0; i < itemObjectData.Length; i++)
        {
            if(itemObjectData[i].itemId == itemId)
            {
                itemObject = itemObjectData[i].itemObject;
            }
        }
       
   
        return itemObject;
    }

}

[System.Serializable]
public class ItemObjectData
{
    public string itemId;
    public ItemObject itemObject;
}
