using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    private const string COINS_KEY = "coins";
    //private const string ITEM_KEY = "Item_";
    private const string SERIALIZED_ITEM_LIST_KEY = "ownedItemsInString";
    private static String ownedItemsSerialized = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    internal static int getNumCoins()
    {
        return PlayerPrefs.GetInt(COINS_KEY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Keep track of owned items in a string and store in PlayerPrefs
    internal static void saveItem(string itemName)
    {

        int currentQty = PlayerPrefs.GetInt(itemName, 0);

        // If player does not hold any of this item, add to serialized item list
        if (currentQty == 0) 
        {
            ownedItemsSerialized = PlayerPrefs.GetString(SERIALIZED_ITEM_LIST_KEY, "");
            ownedItemsSerialized += itemName + ",";
            PlayerPrefs.SetString(SERIALIZED_ITEM_LIST_KEY, ownedItemsSerialized);
            PlayerPrefs.Save();
        }
        

        // Keep track of quantity owned for each item directly with PlayerPrefs
        Debug.Log("PrefsManager.saveItem() | key: " + itemName + " | currentyQty: " + currentQty);
        PlayerPrefs.SetInt(itemName, currentQty + 1);
        PlayerPrefs.Save();

        string[] items = ownedItemsSerialized.Split(',');
        Debug.Log("PrefsManager.saveItem() | serializedItems: " + ownedItemsSerialized + " | numItems: " + items.Length);
        for (int i = 0; i <items.Length; i++)
        {
            Debug.Log("PrefsManager.saveItem() | item[" + i + "]: " + items[i] + " " + PlayerPrefs.GetInt(itemName, 0));
        }
        
    }

    internal static int getItemQty(string itemName)
    {
        return PlayerPrefs.GetInt(itemName, 0);
    }

    internal static String[] getAllOwnedIems()
    {
        return PlayerPrefs.GetString(SERIALIZED_ITEM_LIST_KEY, "").Split(',');
    }
}
