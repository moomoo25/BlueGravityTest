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
        bool isStack = ItemStackHandle(item);

        if (isStack)
        {
            itemManager.OnUpdateValueItem(item,false);
            return;
        }

        items.Add(item);
        itemManager.OnUpdateOneItem(item);
    }
    public void RemoveItemById(ItemObject item_)
    {
        if (items.Count == 0)
            return;

        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].isValue)
            {
                items[i].value--;
                if (items[i].value <= 0)
                {
                    items.RemoveAt(i);
                    itemManager.OnUpdateValueItem(item_, true);
                }
                else
                {
                    itemManager.OnUpdateValueItem(item_,true);
                }
                return;
            }

            if(items[i].id == item_.id)
            {
                items.RemoveAt(i);
            }
        }
    }
    private bool ItemStackHandle(ItemObject item)
    {
        bool isStack = false;
        if (item.isValue)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemId == item.itemId)
                {
                    isStack = true;
                    if (items[i].value == 0)
                    {
                        items[i].value = 1;
                        isStack = false;
                    }
                    else
                    {
                        items[i].value++;
                    }
                }
            }

        }
        return isStack;
    }
    public void ForceCloseInventory()
    {
        itemCanvas.SetActive(false);
        inventoryCanvas.SetActive(false);
        itemManager.RemoveAllChild();
        GameManager.singleton.characterMovement.canMove = true;
    }
}
