using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public GameObject ownedItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ownedItems.transform.childCount; i++)
        {
            Transform slot = ownedItems.transform.GetChild(i);
            GameObject icon = slot.Find("Icon").gameObject;
            GameObject qty = slot.Find("qty").gameObject;
            qty.GetComponent<TextMeshProUGUI>().text = PrefsManager.getItemQty(i) + "x";
        }
    }

    internal void addWood(int v)
    {

    }

    internal void addToInventory(String itemName)
    {
        PrefsManager.saveItem(itemName);
    }
}
