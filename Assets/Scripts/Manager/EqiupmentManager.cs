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
    public void AddHat(string id,Sprite sprite, string text)
    {
        hat.IsAdd(id,sprite, text);
        hatImage.gameObject.SetActive(true);
        hatImage.sprite = sprite;
        hatRenderer.gameObject.SetActive(true);
        hatRenderer.sprite = sprite;
    }
    public void RemoveHat()
    {
        hat.IsRemove();
        hatImage.gameObject.SetActive(false);
        hatRenderer.gameObject.SetActive(false);
    }
    public void AddWeapon(string id,Sprite sprite,string text)
    {
        weapon.IsAdd(id,sprite,text);
        weaponImage.gameObject.SetActive(true);
        weaponImage.sprite = sprite;
        weaponRenderer.gameObject.SetActive(true);
        weaponRenderer.sprite = sprite;
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
        }
        else
        {
            item.id = weapon.id;
            item.itemText = weapon.itemTextMeshPro.text;
            item.itemImage = weapon.itemImage.sprite;
            item.itemMode = weapon.itemMode;
        }
        item.isValue = false;
        return item;
    }
}
