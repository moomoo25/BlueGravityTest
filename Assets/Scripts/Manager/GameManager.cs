using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public CharacterMovement characterMovement;
    public InventoryManager inventoryManager;
    public InventoryController inventoryController;
    public EqiupmentManager eqiupmentManager;
    public ShopManager shopManager;
    public CoinManager coinManager;
    public bool isShopOpen = false;
    void Awake()
    {
        singleton = this;

    }
    private void Start()
    {
        shopManager.SetUp(inventoryManager);
        inventoryController.SetUp(characterMovement, inventoryManager);
    }
    public void OpenShop()
    {
        if (isShopOpen)
            return;
        isShopOpen = true;
        shopManager.OpenShop();
        characterMovement.canMove = !isShopOpen;
    }
    public void CloseShop()
    {
        isShopOpen = false;
        shopManager.CloseShop();
        characterMovement.canMove = !isShopOpen;
    }
    public void ConsumeItem(ItemObject itemObject)
    {
        inventoryManager.RemoveItemById(itemObject);
    }
    public void EquipItem(ItemObject itemObject_)
    {
        inventoryManager.RemoveItemById(itemObject_);
        ItemObject item = eqiupmentManager.GetItemDetail(itemObject_.itemMode);
        eqiupmentManager.AddItemEquipment(itemObject_);
        if (itemObject_.itemMode == itemMode.Hat)
        {
            if(inventoryManager.hasHat)
                AddItemToInventory(item,false);

            inventoryManager.hasHat = true;
        }
        else if(itemObject_.itemMode == itemMode.Weapon)
        {
            if (inventoryManager.hasWeapon)
                AddItemToInventory(item,false);

            inventoryManager.hasWeapon = true;
        }
          
    }
    public void AddItemToInventory(ItemObject item_,bool isGenerateId)
    {
        inventoryManager.AddItem(item_, isGenerateId);
    }
    public void RemoveEquipItem(itemMode itemMode_)
    {
        if (itemMode.Hat == itemMode_)
        {
            if (!inventoryManager.hasHat)
                return;
            inventoryManager.hasHat = false;
            AddItemToInventory(eqiupmentManager.GetItemDetail(itemMode_),false);
        }
        else if(itemMode.Weapon == itemMode_)
        {
            if (!inventoryManager.hasWeapon)
                return;
            inventoryManager.hasWeapon = false;
            AddItemToInventory(eqiupmentManager.GetItemDetail(itemMode_),false);
        }
        eqiupmentManager.RemoveItem(itemMode_);
       
    }

   
    public void BuyItem(ItemObject itemObject_)
    {
      bool isBuy= coinManager.BuyItem(itemObject_.buyPrice);
        if (isBuy)
        {

            AddItemToInventory(itemObject_,true); 
        }

        if (itemObject_.isBuyOnce){
            shopManager.RemoveItemFromShop(itemObject_.itemId);
        }
    }
    public void SellItem(ItemObject itemObject)
    {
        inventoryManager.RemoveItemById(itemObject);
        coinManager.SellItem(itemObject.sellPrice);
    }
}
