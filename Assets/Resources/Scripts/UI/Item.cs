using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public void selectItem()
    {
        Debug.Log("StoreButtons.selectItem() | sprite.name: " + GetComponent<Image>().sprite.name);

        if (WidgetManager.singleton.isState(WidgetManager.MERCHANT_STATE))
        {
            WidgetManager.singleton.getMerchantWidget().setSelectedItem(this, GetComponent<Image>().sprite.name);
        } else if (WidgetManager.singleton.isState(WidgetManager.HUD_STATE))
        {
            Player player = GameApp.singleton.player.GetComponent<Player>();
            if (isItemOfType("Hat"))
            {
                player.setHat(GetComponent<Image>().sprite);
            } else if (isItemOfType("Overall"))
            {

                player.setOverall(GetComponent<Image>().sprite);
            }
            else if (isItemOfType("Gloves"))
            {

                player.setGloves(GetComponent<Image>().sprite);
            }
            else if (isItemOfType("Scarf"))
            {

                player.setScarf(GetComponent<Image>().sprite);
            }
        }
    }

    private bool isItemOfType(String type)
    {
        if (getName().Contains(type))
            return true;
        return false;
    }

    public string getName()
    {
        return GetComponent<Image>().sprite.name;
    }

    internal void updateQtyText()
    {
        transform.Find("qty").GetComponent<TextMeshProUGUI>().text = PrefsManager.getItemQty(getName()) + "";
        if (PrefsManager.getItemQty(getName()) == 0)
        {
            Destroy(gameObject);
            PrefsManager.removeItemFromSerializedList(getName());
        }
    }

    internal bool belongsToPlayer()
    {
        return transform.parent.parent.name.Equals("ownedItems");
    }
}
