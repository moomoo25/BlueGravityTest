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
            weapon.IsAdd(itemObject_.id, itemObject_.itemImage, itemObject_.itemText, itemObject_.sellPrice);
        }

    }
    private void AddItemEquipmentHandle(ItemEquipment itemEquipment, Image image, SpriteRenderer spriteRenderer,ItemObject item)
    {
        itemEquipment.IsAdd(item.id, item.itemImage, item.itemText, item.sellPrice);
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
        print("sda");
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
            item.id = hat.id;
            item.itemText = hat.itemTextMeshPro.text;
            item.itemMode = hat.itemMode;
            item.itemImage = hat.itemImage.sprite;
            item.sellPrice = hat.sellPrice;
            item.buyPrice = hat.buyPrice;
        }
        else
        {
            item.id = weapon.id;
            item.itemText = weapon.itemTextMeshPro.text;
            item.itemImage = weapon.itemImage.sprite;
            item.itemMode = weapon.itemMode;
            item.sellPrice = weapon.sellPrice;
            item.buyPrice = weapon.buyPrice;
        }
        item.isValue = false;
        return item;
    }
}
