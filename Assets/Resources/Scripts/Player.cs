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
        GetComponent<PlayerController>().speed = 400f;
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
    }
}
