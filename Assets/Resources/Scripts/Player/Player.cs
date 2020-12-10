using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        gameObject.AddComponent<CircleCollider2D>();
        gameObject.GetComponent<CircleCollider2D>().radius = 0.1f;
        gameObject.AddComponent<PlayerController>();
        GetComponent<PlayerController>().speed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player.Update() | KeyCode.E");
            if (WidgetManager.singleton.getCurrentInteractSign() != null)
            {
                Debug.Log("Player.Update() | getCurrentInteractSign() != null | name: " + WidgetManager.singleton.getCurrentInteractSign().name);
                if (WidgetManager.singleton.getCurrentInteractSign().name.Equals("MerchantSign"))
                {
                    WidgetManager.singleton.setState(WidgetManager.MERCHANT_STATE);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (WidgetManager.singleton.getState() == WidgetManager.HUD_STATE)
            {
                Application.Quit();
            } else if (WidgetManager.singleton.getState() == WidgetManager.MERCHANT_STATE)
            {
                WidgetManager.singleton.setState(WidgetManager.HUD_STATE);
            }
        }
    }

    internal void setScarf(Sprite sprite)
    {
        transform.Find("Tie").GetComponent<SpriteRenderer>().sprite = sprite;
    }

    internal void setGloves(Sprite sprite)
    {

        transform.Find("LeftGlove").GetComponent<SpriteRenderer>().sprite = sprite;
        transform.Find("RightGlove").GetComponent<SpriteRenderer>().sprite = sprite;
        transform.Find("RightGlove").GetComponent<SpriteRenderer>().flipX = true;

    }

    internal void setOverall(Sprite sprite)
    {
        transform.Find("Body").GetComponent<SpriteRenderer>().sprite = sprite;
    }

    internal void setHat(Sprite sprite)
    {
        transform.Find("Hat").GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
