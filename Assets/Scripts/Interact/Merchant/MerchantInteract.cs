using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantInteract : InteracableObject
{
    public List<ShopItemsSetting> shopItems = new List<ShopItemsSetting>();
    public override void OnInteract()
    {
        GameManager.singleton.OpenShop();
        ShopManager.singleton.SetUpShop(this,shopItems);
    }
}
