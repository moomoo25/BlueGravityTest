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
    public bool hasWeapon;
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
    public void AddItem(ItemObject item , bool isGenerateId)
    {
        bool isStack = ItemStackHandle(item);

        if (isStack)
        {
            itemManager.OnUpdateValueItem(item,false);
            return;
        }
     

            ItemObject item_ = new ItemObject();
            if (isGenerateId)
            {
                item_.id = UniqueIdManager.singleton.GetUniqueId();
            }
            else
            {
                item_.id = item.id;
            }
        
            item_.itemId = item.itemId;
            item_.itemImage = item.itemImage;
            item_.itemText = item.itemText;
            item_.value = item.value;
            item_.buyPrice = item.buyPrice;
            item_.sellPrice = item.sellPrice;
            item_.isBuyOnce = item.isBuyOnce;
            item_.itemMode = item.itemMode;
            items.Add(item_);
            itemManager.OnUpdateOneItem(item_);
     

    
    }
    public void RemoveItemById(ItemObject item_)
    {
        if (items.Count == 0)
            return;

        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].itemMode==itemMode.Consumer)
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
        if (item.itemMode == itemMode.Consumer)
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
