using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager singleton;
    [HideInInspector] public MerchantInteract merchantInteract;
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
    public void SetUpShop(MerchantInteract merchantInteract_ , List<ShopItemsSetting> itemsId)
    {
        if(merchantInteract_!=null)
            merchantInteract = merchantInteract_;

        if (itemsId.Count > 0)
        {
            List<ItemObject> itemObjects = new List<ItemObject>();
            for (int i = 0; i < itemsId.Count; i++)
            {
                ItemObject itemObject = ItemObjectData.GetItemById(itemsId[i].itemId);
                itemObject.itemId = itemsId[i].itemId;
                itemObject.isBuyOnce = itemsId[i].isBuyOnce;

                if (!string.IsNullOrEmpty(itemObject.id))
                    itemObjects.Add(itemObject);
            }
          
            if (itemObjects.Count > 0)
            {
                itemManager.SetUpShopItem(itemObjects);
            }
            
        }
        
    }
    public void RemoveItemFromShop(string id) 
    {
        if (merchantInteract != null)
        {
            for (int i = 0; i < merchantInteract.shopItems.Count; i++)
            {
                if(id == merchantInteract.shopItems[i].itemId)
                {
                    merchantInteract.shopItems.Remove(merchantInteract.shopItems[i]);
                }
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
[System.Serializable]
public class ShopItemsSetting
{
    public string itemId;
    public bool isBuyOnce;
}