using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemObject 
{
    public string id;
    public string itemId;
    public Sprite itemImage;
    public string itemText;
    public int value;
    public int sellPrice;
    public int buyPrice;
    public bool isBuyOnce;
    public itemMode itemMode = itemMode.Consumer;
}
public enum itemMode
{
    Consumer,
    Hat,
    Weapon
}