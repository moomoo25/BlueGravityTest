using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryCanvas;
    private ItemManager itemManager;
    [SerializeField]private ItemManager itemCharacterManager;
    [SerializeField] private ItemManager itemShopManager;
    [Header("Equipment")]
    public bool hasHat;
    public ItemObject itemHatObject;
    public bool hasWeapon;
    public ItemObject itemWeaponObject;
    [Header("PlayerItems")]
    public List<ItemObject> items = new List<ItemObject>();

    void Awake()
    {
        inventoryCanvas.SetActive(false);
    }
    private void Start()
    {
        itemCharacterManager.SetUp(this);
        itemShopManager.SetUp(this);
    }
    public void EnableShopPanel(bool isEnable)
    {
        if (isEnable)
        {
            itemManager = itemShopManager;
            itemManager.OnUpdateItemList();
        }
        else
        {
            itemManager = itemCharacterManager;
        }
   
    }
    public bool EnableInventory()
    {
        inventoryCanvas.SetActive(!inventoryCanvas.activeInHierarchy);
        if (inventoryCanvas.activeInHierarchy)
        {
            itemManager = itemCharacterManager;
            itemManager.OnUpdateItemList();
            return true;
        }
        else
        {
            itemManager.RemoveAllChild();
            itemManager = itemShopManager;
            return false;
        }
    }
    public void AddItem(ItemObject item)
    {
        items.Add(item);
        itemManager.OnUpdateOneItem(item);
    }
    public void RemoveItemById(string id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].id == id)
            {
                items.RemoveAt(i);
            }
        }
    }
    public void ForceCloseInventory()
    {
        inventoryCanvas.SetActive(false);
        itemCharacterManager.RemoveAllChild();
        GameManager.singleton.characterMovement.canMove = true;
    }
}
