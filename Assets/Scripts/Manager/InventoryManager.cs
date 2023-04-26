using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public GameObject itemCanvas;
    [SerializeField] private ItemManager itemManager;
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
        itemCanvas.SetActive(false);
    }
    private void Start()
    {
        itemManager.SetUp(this);
    }
    public void EnableShopPanel(bool isShopOpen)
    {
     
        if (isShopOpen)
        {
            itemManager.OnUpdateItemList();
            itemCanvas.SetActive(true);
        }
        else
        {
            itemManager.RemoveAllChild();
            itemCanvas.SetActive(false);
        }
    }
    public bool EnableInventory()
    {
        inventoryCanvas.SetActive(!inventoryCanvas.activeInHierarchy);
        if (inventoryCanvas.activeInHierarchy)
        {
            itemManager.OnUpdateItemList();
            itemCanvas.SetActive(true);
            return true;
        }
        else
        {
            itemManager.RemoveAllChild();
            itemCanvas.SetActive(false);
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
        if (items.Count == 0)
            return;

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
        itemCanvas.SetActive(false);
        inventoryCanvas.SetActive(false);
        itemManager.RemoveAllChild();
        GameManager.singleton.characterMovement.canMove = true;
    }
}
