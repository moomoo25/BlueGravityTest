using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform content;
    private InventoryManager inventoryManager;
    public void SetUp(InventoryManager inventoryManager_)
    {
        inventoryManager = inventoryManager_;
    }

    public void OnUpdateItemList()
    {
        List<ItemObject> items = inventoryManager.items;
        if (items.Count == 0)
            return;

      
        for (int i = 0; i < items.Count; i++)
        {
            OnUpdateOneItem(items[i]);
        }
    }

    public void OnUpdateOneItem(ItemObject item)
    {
        GameObject g = Instantiate(itemPrefab,transform.position,Quaternion.identity);
        g.transform.SetParent(content);
        g.transform.localPosition = Vector3.zero;
        g.transform.localScale = Vector3.one;

        if (GameManager.singleton.isShopOpen)
        {
            ItemShop itemObject_ = g.GetComponent<ItemShop>();
            itemObject_.isBuy = false;
            itemObject_.SetUpBuyButton();
            itemObject_.SetUpItemDetail(item.id, item.itemImage, item.itemText, item.isValue, item.value, item.itemMode, item.sellPrice, item.buyPrice);
        }
        else
        {
            ItemCharacter itemObject_ = g.GetComponent<ItemCharacter>();
            itemObject_.SetUpItemDetail(item.id, item.itemImage, item.itemText, item.isValue, item.value, item.itemMode, item.sellPrice, item.buyPrice);
        }
  
    }
    public void RemoveAllChild()
    {
        foreach (Transform child in content)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
