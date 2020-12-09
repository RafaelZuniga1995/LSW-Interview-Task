using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] public GameObject ownedItems;
    private int NUM_ITEMS = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Load items in each tab from "Resources/Textures/UI/Tabs/...
        for (int i = 0; i < NUM_ITEMS; i++)
        {
            GameObject slot = Instantiate(slotPrefab);
            slot.transform.parent = hats.transform.Find("Items");
            slot.transform.localScale = Vector3.one;
            Sprite sprite = Resources.Load<Sprite>("Textures/UI/Tabs/Hats/Hat_" + (i + 1));
            slot.transform.Find("Icon").GetComponent<Image>().sprite = sprite;

            slot = Instantiate(slotPrefab);
            slot.transform.parent = overalls.transform.Find("Items");
            slot.transform.localScale = Vector3.one;
            sprite = Resources.Load<Sprite>("Textures/UI/Tabs/Overalls/Overall_" + (i + 1));
            slot.transform.Find("Icon").GetComponent<Image>().sprite = sprite;

            slot = Instantiate(slotPrefab);
            slot.transform.parent = gloves.transform.Find("Items");
            slot.transform.localScale = Vector3.one;
            sprite = Resources.Load<Sprite>("Textures/UI/Tabs/Gloves/Gloves_" + (i + 1));
            slot.transform.Find("Icon").GetComponent<Image>().sprite = sprite;

            slot = Instantiate(slotPrefab);
            slot.transform.parent = scarves.transform.Find("Items");
            slot.transform.localScale = Vector3.one;
            sprite = Resources.Load<Sprite>("Textures/UI/Tabs/Scarves/Scarf_" + (i + 1));
            slot.transform.Find("Icon").GetComponent<Image>().sprite = sprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
