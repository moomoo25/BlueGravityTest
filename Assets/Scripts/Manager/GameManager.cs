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
    public CoinManager coinManager;
    [SerializeField]private GameObject shopCanvas;
    private PlayerInput input = null;
    public bool isShopOpen = false;
    void Awake()
    {
        singleton = this;
        shopCanvas.gameObject.SetActive(false);
        input = new PlayerInput();
    }
    public void OpenShop()
    {
        if (isShopOpen)
            return;
        shopCanvas.gameObject.SetActive(true);
        isShopOpen = true;
        inventoryManager.ForceCloseInventory();
        if (isShopOpen)
        {
            inventoryManager.EnableShopPanel(isShopOpen);
           
        }
        characterMovement.canMove = false;
    }
    public void CloseShop()
    {
        isShopOpen = false;
        inventoryManager.EnableShopPanel(isShopOpen);
        shopCanvas.gameObject.SetActive(false);
        characterMovement.canMove = true;
    }
    public void EquipHat(ItemObject itemObject_)
    {
        inventoryManager.RemoveItemById(itemObject_.id);
        if (inventoryManager.hasHat)
        {
            ItemObject item = eqiupmentManager.GetItemDetail(false);
            if (itemObject_.id == item.id)
            {
                return;
            }
            
            AddItemToInventory(item);
        }
        eqiupmentManager.AddHat(itemObject_);
        inventoryManager.hasHat = true;
    }
    public void EquipWeapon(ItemObject itemObject_)
    {
        inventoryManager.RemoveItemById(itemObject_.id);
        if (inventoryManager.hasWeapon)
        {
            ItemObject item = eqiupmentManager.GetItemDetail(true);
            if (itemObject_.id == item.id)
                return;
            AddItemToInventory(item);
        }
        eqiupmentManager.AddWeapon(itemObject_);
        inventoryManager.hasWeapon = true;

    }
    public void AddItemToInventory(ItemObject item_)
    {
        inventoryManager.AddItem(item_);
    }
    public void RemoveEquipHat()
    {
        if (!inventoryManager.hasHat)
            return;
        AddItemToInventory(eqiupmentManager.GetItemDetail(false));
        eqiupmentManager.RemoveHat();
        inventoryManager.hasHat = false;
    }
    public void RemoveEquipWeapon()
    {
        if (!inventoryManager.hasWeapon)
            return;
        AddItemToInventory(eqiupmentManager.GetItemDetail(true));
        inventoryManager.hasWeapon = false;
        eqiupmentManager.RemoveWeapon();
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
    }
    public void SellItem(string id,int price)
    {
        inventoryManager.RemoveItemById(id);
        coinManager.SellItem(price);
    }
}
