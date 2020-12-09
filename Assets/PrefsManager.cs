using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    private const string COINS_KEY = "coins";
    private const string _KEY = "coins";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal static void saveItem(string itemName)
    {
        int currentQty = PlayerPrefs.GetInt(itemName, 0);
        Debug.Log("PrefsManager.saveItem() | key: " + itemName + " | currentyQty: " + currentQty);
        PlayerPrefs.SetInt(itemName, currentQty + 1);
        PlayerPrefs.Save();
    }

    internal static int getItemQty(int i)
    {
        return PlayerPrefs.GetInt(("Items_"  + i), 0);
    }
}
