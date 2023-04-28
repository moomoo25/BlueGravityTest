using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemCharacterPrefab;
    public GameObject itemShopPrefab;
    public Transform content;
    private InventoryManager inventoryManager;

    //Shop
    private bool isShopSlot;
    [SerializeField] private List<ItemObject> items = new List<ItemObject>();
    public void SetUp(InventoryManager inventoryManager_)
    {
        inventoryManager = inventoryManager_;
    }

    public void OnUpdateItemList()
    {
        if (inventoryManager != null)
            items = inventoryManager.items;

        if (items.Count == 0)
            return;


        for (int i = 0; i < items.Count; i++)
        {
            OnUpdateOneItem(items[i]);
        }
    }
    public void SetUpShopItem(List<ItemObject> itemsShop)
    {
        isShopSlot = true;
        items = itemsShop;
        OnUpdateItemList();
    }
    public void OnUpdateOneItem(ItemObject item)
    {
        GameObject slot = GameManager.singleton.isShopOpen ? itemShopPrefab : itemCharacterPrefab;
        GameObject g = Instantiate(slot, transform.position, Quaternion.identity);
        g.transform.SetParent(content);
        g.transform.localPosition = Vector3.zero;
        g.transform.localScale = Vector3.one;

        if (item.isValue)
        {
            if (item.value == 0)
            {
                item.value = 1;
            }
        }
      
        if (GameManager.singleton.isShopOpen)
        {
            ItemShop itemObject_ = g.GetComponent<ItemShop>();
            itemObject_.isBuySlot = isShopSlot?true:false;
            itemObject_.SetUpBuyButton();
            itemObject_.SetUpItemDetail(item);
        }
        else if(GameManager.singleton.isShopOpen==false)
        {
            ItemCharacter itemObject_ = g.GetComponent<ItemCharacter>();
            itemObject_.SetUpItemDetail(item);
        }
  
    }
    public void OnUpdateValueItem(ItemObject item,bool isRemove)
    {
        Item[] itemsContent = content.GetComponentsInChildren<Item>();
        for (int i = 0; i < itemsContent.Length; i++)
        {
            if (itemsContent[i].itemObject.itemId == item.itemId)
            {
                if (isRemove)
                    item.value--;

                itemsContent[i].UpdateValue(item.value);
            }
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
