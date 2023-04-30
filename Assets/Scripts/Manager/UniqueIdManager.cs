using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueIdManager : MonoBehaviour
{
    public static UniqueIdManager singleton;
    public int number = 0;
    void Awake()
    {
        singleton = this;
    }

   public string GetUniqueId()
    {
        string id = "";
        number = number + 1;
        id = number.ToString("00000000");
        return id;
    }
}
