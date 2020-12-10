using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetManager : MonoBehaviour
{
    public static WidgetManager singleton;
    public const int HUD_STATE = 0;
    public const int MERCHANT_STATE = 1;

    [SerializeField] public GameObject hud;
    [SerializeField] public GameObject merchant;
    private int currentState;
    private GameObject interactSign;
    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
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
            case HUD_STATE:
                hud.SetActive(true);
                merchant.SetActive(false);
                break;
            case MERCHANT_STATE:
                //hud.SetActive(false);
                merchant.SetActive(true);
                interactSign.SetActive(false);
                break;
        }
    }

    public GameObject getCurrentInteractSign()
    {
        return interactSign;
    }
    public void setCurrentInteractSign(GameObject interactSign)
    {
        this.interactSign = interactSign;
    }

    internal Inventory getInventory()
    {
        return hud.transform.Find("Inventory").GetComponent<Inventory>();
    }

    internal int getState()
    {
        return currentState;
    }

    internal MerchantWidget getMerchantWidget()
    {
        return merchant.GetComponent<MerchantWidget>();
    }

    internal bool isState(int state)
    {
        return currentState == state;
    }
}
