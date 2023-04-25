using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemObject 
{
    public string id;
    public Sprite itemImage;
    public string itemText;
    public bool isValue;
    public int value;
    public int sellPrice;
    public int buyPrice;
    public itemMode itemMode = itemMode.Consumer;
}
public enum itemMode
{
    Consumer,
    Hat,
    Weapon
}