using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButtons : MonoBehaviour
{
    [SerializeField] public MerchantWidget merchantWidget;
    public void setBuy()
    {
        WidgetManager.singleton.getMerchantWidget().setState(MerchantWidget.BUY_STATE);
    }

    public void setSell()
    {
        WidgetManager.singleton.getMerchantWidget().setState(MerchantWidget.SELL_STATE);
    }

    public void showHats()
    {
        WidgetManager.singleton.getMerchantWidget().setState(MerchantWidget.HATS_STATE);
    }

    public void showOveralls()
    {
        WidgetManager.singleton.getMerchantWidget().setState(MerchantWidget.OVERALLS_STATE);
    }


    public void showGloves ()
    {
        WidgetManager.singleton.getMerchantWidget().setState(MerchantWidget.GLOVES_STATE);
    }

    public void showBoots()
    {
        WidgetManager.singleton.getMerchantWidget().setState(MerchantWidget.BOOTS_STATE);
    }
}
