using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager singleton;
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private ItemDetailScriptableObject ItemObjectData;
    private InventoryManager inventoryManager = null;
    void Awake()
    {
        singleton = this;
        shopCanvas.gameObject.SetActive(false);
    }
    public void SetUp( InventoryManager inventoryManager_)
    {
        inventoryManager = inventoryManager_;
    }
    public void SetUpShop(List<string> itemsId)
    {
        if (itemsId.Count > 0)
        {
            List<ItemObject> itemObjects = new List<ItemObject>();
            for (int i = 0; i < itemsId.Count; i++)
            {
                ItemObject itemObject = ItemObjectData.GetItemById(itemsId[i]);
             
                if (!string.IsNullOrEmpty(itemObject.id))
                    itemObjects.Add(itemObject);
            }
          
            if (itemObjects.Count > 0)
            {
                itemManager.SetUpShopItem(itemObjects);
            }
            
        }
        
    }
    public void OpenShop()
    {
        shopCanvas.gameObject.SetActive(true);
        inventoryManager.ForceCloseInventory();
        inventoryManager.EnableShopPanel(true);
    }
    public void CloseShop()
    {
        shopCanvas.gameObject.SetActive(false);
        inventoryManager.EnableShopPanel(false);
        itemManager.RemoveAllChild();
    }


}
