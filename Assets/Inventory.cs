using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public GameObject ownedItems;
    [SerializeField] public GameObject itemPrefab;
    [SerializeField] public Sprite[] allItemSprites;

    // Start is called before the first frame update
    void Start()
    {
        // load owned items
        String[] items = PrefsManager.getAllOwnedIems();
        for (int i = 0; i < items.Length; i++)
        {

            String itemName = items[i];
            if (itemName.Equals(""))
                break;
            GameObject item = Instantiate(itemPrefab, ownedItems.transform.GetChild(i));
            item.GetComponent<Image>().sprite = getSprite(itemName);
            item.transform.Find("qty").GetComponent<TextMeshProUGUI>().text = PrefsManager.getItemQty(itemName) + "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < ownedItems.transform.childCount; i++)
        {
            Transform slot = ownedItems.transform.GetChild(i);
            GameObject icon = slot.Find("Icon").gameObject;
            GameObject qty = slot.Find("qty").gameObject;
            qty.GetComponent<TextMeshProUGUI>().text = PrefsManager.getItemQty(i) + "x";
        }
        */
    }

    internal void addWood(int v)
    {

    }

    internal void addToInventory(String itemName)
    {
        Transform slotToPutIn = null;

        // Do we already own this item?
        if (PrefsManager.getItemQty(itemName) != 0)
        {
            Debug.Log("Inventory.addToInventory() | We Already Own this item");
            // We own at least 1 of this item. Find the slot
            for (int i = 0; i < ownedItems.transform.childCount; i++)
            {
                Transform slot = ownedItems.transform.GetChild(i);
                if (slot.childCount != 0)
                {
                    // if this slot is not empty. Is it itemName?
                    if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name.Equals(itemName))
                    {
                        slotToPutIn = slot;
                    }

                }
            }
        } else
        {
            Debug.Log("Inventory.addToInventory() | We do Not own this item");
            // find empty slot
            for (int i = 0; i < ownedItems.transform.childCount; i++)
            {
                Transform slot = ownedItems.transform.GetChild(i);
                if (slot.childCount == 0)
                {
                    slotToPutIn = slot;
                    break;
                }
            }
            GameObject item = Instantiate(itemPrefab, slotToPutIn);
            item.GetComponent<Image>().sprite = getSprite(itemName);
        }




        // If we have a slot with this item already in it or there is an empty slot. Add to inventory
        if (slotToPutIn != null)
        {
            PrefsManager.saveItem(itemName);
            slotToPutIn.transform.GetChild(0).transform.Find("qty").GetComponent<TextMeshProUGUI>().text = PrefsManager.getItemQty(itemName) + "";
        }

    }

    private Sprite getSprite(string itemName)
    {
        foreach (Sprite sprite in allItemSprites)
        {
            Debug.Log("spriteName: " + sprite.name);
            if (sprite.name.Equals(itemName))
                return sprite;
        }
        return null;
    }
}
