using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButtons : MonoBehaviour
{
    public void exit()
    {
        WidgetManager.singleton.setState(WidgetManager.HUD_STATE);
    }

    public void buyItem()
    {

        WidgetManager.singleton.getMerchantWidget().buySelectedItem();
    }

    public void sellItem()
    {
        WidgetManager.singleton.getMerchantWidget().sellSelectedItem();
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
