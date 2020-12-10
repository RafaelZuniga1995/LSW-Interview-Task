using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerchantWidget : MonoBehaviour
{
    public const int BUY_STATE = 0;
    public const int SELL_STATE = 1;
    public const int HATS_STATE = 10;
    public const int OVERALLS_STATE = 11;
    public const int GLOVES_STATE = 12;
    public const int BOOTS_STATE = 13;
    private int currentState;
    //public GameObject buyWidget;
    //public GameObject sellWidget;

    [SerializeField] public GameObject hats;
    [SerializeField] public GameObject overalls;
    [SerializeField] public GameObject gloves;
    [SerializeField] public GameObject scarves;
    [SerializeField] public GameObject slotPrefab;

    [SerializeField] public Item selectedItemScript;
    [SerializeField] public GameObject selectedItem;
    [SerializeField] public GameObject selectedItemName;
    [SerializeField] public GameObject selectedItemPrice;
    [SerializeField] public GameObject buyButton;
    [SerializeField] public GameObject sellButton;

    //[SerializeField] public GameObject ownedItems;
    private int NUM_ITEMS = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Load items in each tab from "Resources/Textures/UI/Tabs/...
        for (int i = 0; i < NUM_ITEMS; i++)
        {
            GameObject item = Instantiate(slotPrefab, hats.transform.Find("Items").GetChild(i));
            Sprite sprite = Resources.Load<Sprite>("Textures/UI/MerchantWidget/Hats/Hat_" + (i + 1));
            item.GetComponent<Image>().sprite = sprite;

            
            item = Instantiate(slotPrefab, overalls.transform.Find("Items").GetChild(i));
            sprite = Resources.Load<Sprite>("Textures/UI/MerchantWidget/Overalls/Overall_" + (i + 1));
            item.GetComponent<Image>().sprite = sprite;
            
            item = Instantiate(slotPrefab, gloves.transform.Find("Items").GetChild(i));
            sprite = Resources.Load<Sprite>("Textures/UI/MerchantWidget/Gloves/Gloves_" + (i + 1));
            item.GetComponent<Image>().sprite = sprite;

            item = Instantiate(slotPrefab, scarves.transform.Find("Items").GetChild(i));
            sprite = Resources.Load<Sprite>("Textures/UI/MerchantWidget/Scarves/Scarf_" + (i + 1));
            item.GetComponent<Image>().sprite = sprite;
            
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
            //qty.GetComponent<TextMeshProUGUI>().text = PrefsManager.getItemQty(i) + "x";
        }
        */
    }

    public void setState(int state)
    {
        currentState = state;

        switch (currentState)
        {
            case BUY_STATE:

                break;
            case SELL_STATE:

                break;

            case HATS_STATE:
                hats.SetActive(true);
                overalls.SetActive(false);
                gloves.SetActive(false);
                scarves.SetActive(false);
                break;
            case OVERALLS_STATE:

                hats.SetActive(false);
                overalls.SetActive(true);
                gloves.SetActive(false);
                scarves.SetActive(false);
                break;
            case GLOVES_STATE:

                hats.SetActive(false);
                overalls.SetActive(false);
                gloves.SetActive(true);
                scarves.SetActive(false);
                break;
            case BOOTS_STATE:

                hats.SetActive(false);
                overalls.SetActive(false);
                gloves.SetActive(false);
                scarves.SetActive(true);
                break;
        }
    }

    public void setSelectedItem(Item item, string itemName)
    {
        selectedItemScript = item;
        selectedItem.SetActive(true);
        selectedItem.GetComponent<Image>().sprite = WidgetManager.singleton.getInventory().getSprite(itemName);
        selectedItemName.GetComponent<TextMeshProUGUI>().text = itemName;
        selectedItemPrice.GetComponent<TextMeshProUGUI>().text = getPrice(itemName) + "";

        if (PrefsManager.getItemQty(itemName) > 0 && selectedItemScript.belongsToPlayer())
        {
            // Player can sell
            buyButton.SetActive(false);
            sellButton.SetActive(true);
        } else
        {
            buyButton.SetActive(true);
            sellButton.SetActive(false);
        }
    }

    private int getPrice(string itemName)
    {
        switch(itemName)
        {
            case "Items_0":
                return 5;
            case "Items_1":
                return 10;
            case "Items_2":
                return 15;
        }

        return 12;
    }

    internal void sellSelectedItem()
    {
        String itemName = selectedItemScript.getName();
        Debug.Log("MerchantWidget.sellSelectedItem() | itemName: " + itemName);

        if (PrefsManager.attemptToSellItem(itemName))
        {
            PrefsManager.addCoins(getPrice(itemName));
            selectedItemScript.updateQtyText();
        }
        
    }

    internal void buySelectedItem()
    {
        if (!WidgetManager.singleton.getInventory().hasEmptySlots())
        {
            return;
        }

        String itemName = selectedItemScript.getName();
        Debug.Log("MerchantWidget.buySelectedItem() | itemName: " + itemName);
        if (PrefsManager.attemptCoinPurchase(getPrice(itemName)))
        {
            WidgetManager.singleton.getInventory().addToInventory(itemName);
            selectedItemScript.updateQtyText();

        }
    }
}
