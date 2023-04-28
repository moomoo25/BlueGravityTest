using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public CharacterMovement characterMovement;
    public InventoryManager inventoryManager;
    public EqiupmentManager eqiupmentManager;
    public ShopManager shopManager;
    public CoinManager coinManager;
    private PlayerInput input = null;
    public bool isShopOpen = false;
    void Awake()
    {
        singleton = this;
        input = new PlayerInput();
    }
    private void Start()
    {
        shopManager.SetUp(inventoryManager);
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
    public void EquipItem(ItemObject itemObject_)
    {
        inventoryManager.RemoveItemById(itemObject_.id);
        ItemObject item = eqiupmentManager.GetItemDetail(itemObject_.itemMode);
        eqiupmentManager.AddItemEquipment(itemObject_);
        if (itemObject_.itemMode == itemMode.Hat)
        {
            if(inventoryManager.hasHat)
                AddItemToInventory(item);

            inventoryManager.hasHat = true;
        }
        else if(itemObject_.itemMode == itemMode.Weapon)
        {
            if (inventoryManager.hasWeapon)
                AddItemToInventory(item);

            inventoryManager.hasWeapon = true;
        }
          
    }
    public void AddItemToInventory(ItemObject item_)
    {
        inventoryManager.AddItem(item_);
    }
    public void RemoveEquipItem(itemMode itemMode_)
    {
        if (itemMode.Hat == itemMode_)
        {
            if (!inventoryManager.hasHat)
                return;
            inventoryManager.hasHat = false;
            AddItemToInventory(eqiupmentManager.GetItemDetail(itemMode_));
        }
        else if(itemMode.Weapon == itemMode_)
        {
            if (!inventoryManager.hasWeapon)
                return;
            inventoryManager.hasWeapon = false;
            AddItemToInventory(eqiupmentManager.GetItemDetail(itemMode_));
        }
        eqiupmentManager.RemoveItem(itemMode_);
       
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Inventory.performed += OnInventoryPerformed;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Inventory.performed -= OnInventoryPerformed;
    }
    private void OnInventoryPerformed(InputAction.CallbackContext value)
    {
        if (isShopOpen)
            return;
        characterMovement.canMove = !inventoryManager.EnableInventory();
    }
    public void BuyItem(ItemObject itemObject_)
    {
      bool isBuy= coinManager.BuyItem(itemObject_.buyPrice);
        if (isBuy)
        {
            AddItemToInventory(itemObject_); 
        }

        if (itemObject_.isBuyOnce){
            shopManager.RemoveItemFromShop(itemObject_.itemId);
        }
    }
    public void SellItem(string id,int price)
    {
        inventoryManager.RemoveItemById(id);
        coinManager.SellItem(price);
    }
}
