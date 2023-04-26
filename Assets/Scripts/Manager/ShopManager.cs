using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    private InventoryManager inventoryManager = null;
    void Awake()
    {
        shopCanvas.gameObject.SetActive(false);
    }
    public void SetUp( InventoryManager inventoryManager_)
    {
        inventoryManager = inventoryManager_;
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
    }
}
