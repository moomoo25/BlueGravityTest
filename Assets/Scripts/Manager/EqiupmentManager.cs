using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EqiupmentManager : MonoBehaviour
{
    [Header("UI")]
    public Image hatImage;
    public Image weaponImage;
    [Header("Character")]
    public SpriteRenderer hatRenderer;
    public SpriteRenderer weaponRenderer;
    [Header("Object")]
    public ItemEquipment hat;
    public ItemEquipment weapon;
    // Start is called before the first frame update
    public void AddItemEquipment(ItemObject itemObject_)
    {
        if(itemObject_.itemMode == itemMode.Hat)
        {
            AddItemEquipmentHandle(hat,hatImage,hatRenderer,itemObject_);
        }
        else if(itemObject_.itemMode == itemMode.Weapon)
        {
            AddItemEquipmentHandle(weapon,weaponImage,weaponRenderer,itemObject_);
        }

    }
    private void AddItemEquipmentHandle(ItemEquipment itemEquipment, Image image, SpriteRenderer spriteRenderer,ItemObject item)
    {
        itemEquipment.IsAdd(item);
        image.gameObject.SetActive(true);
        image.sprite = item.itemImage;
        spriteRenderer.gameObject.SetActive(true);
        spriteRenderer.sprite = item.itemImage;
    }
    public void RemoveItem(itemMode itemMode_)
    {
        if(itemMode_ == itemMode.Hat)
        {
            RemoveItemHandle(hat, hatImage, hatRenderer);
        }
        else if(itemMode_ == itemMode.Weapon)
        {
            RemoveItemHandle(weapon, weaponImage, weaponRenderer);
        }
    }
    private void RemoveItemHandle(ItemEquipment itemEquipment , Image image , SpriteRenderer spriteRenderer)
    {
        itemEquipment.IsRemove();
        image.gameObject.SetActive(false);
        spriteRenderer.gameObject.SetActive(false);
    }
    public ItemObject GetItemDetail(itemMode mode)
    {
        ItemObject item = new ItemObject();
        if (mode == itemMode.Hat)
        {
            item = GetItemDetailHandle(hat);
        }
        else
        {
            item = GetItemDetailHandle(weapon);
        }
       // item.isValue = false;
        return item;
    }
    private ItemObject GetItemDetailHandle(ItemEquipment itemEquipment)
    {
        ItemObject item = itemEquipment.itemObject;
        return item;
    }
}
