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
    public void AddHat(ItemObject itemObject_)
    {
        hat.IsAdd(itemObject_.id, itemObject_.itemImage, itemObject_.itemText,itemObject_.sellPrice);
        hatImage.gameObject.SetActive(true);
        hatImage.sprite = itemObject_.itemImage;
        hatRenderer.gameObject.SetActive(true);
        hatRenderer.sprite = itemObject_.itemImage;
    }
    public void RemoveHat()
    {
        hat.IsRemove();
        hatImage.gameObject.SetActive(false);
        hatRenderer.gameObject.SetActive(false);
    }
    public void AddWeapon(ItemObject itemObject_)
    {
        weapon.IsAdd(itemObject_.id, itemObject_.itemImage, itemObject_.itemText,itemObject_.sellPrice);
        weaponImage.gameObject.SetActive(true);
        weaponImage.sprite = itemObject_.itemImage;
        weaponRenderer.gameObject.SetActive(true);
        weaponRenderer.sprite = itemObject_.itemImage;
    }
    public void RemoveWeapon()
    {
        weapon.IsRemove();
        weaponImage.gameObject.SetActive(false);
        weaponRenderer.gameObject.SetActive(false);
    }
    public ItemObject GetItemDetail(bool isWeapon)
    {
        ItemObject item = new ItemObject();
        if (!isWeapon)
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
