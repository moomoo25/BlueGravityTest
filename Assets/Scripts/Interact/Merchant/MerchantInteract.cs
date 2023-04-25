using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantInteract : InteracableObject
{
    public override void OnInteract()
    {
        GameManager.singleton.OpenShop();
    }
}
