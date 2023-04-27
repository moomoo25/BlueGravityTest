using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantInteract : InteracableObject
{
    public List<string> items = new List<string>();
    public override void OnInteract()
    {
        GameManager.singleton.OpenShop();
        ShopManager.singleton.SetUpShop(items);
    }
}
