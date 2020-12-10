using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
        } else if (Input.GetKeyDown(KeyCode.W))
        {

        }
    }

    private void FixedUpdate()
    {
        if (WidgetManager.singleton.isState(WidgetManager.MERCHANT_STATE))
        {
            return;
        }
        Vector2 target = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.fixedDeltaTime;
        Vector2 vel = Vector2.zero;
        GetComponent<Rigidbody2D>().velocity = Vector2.SmoothDamp(GetComponent<Rigidbody2D>().velocity, target, ref vel, 0.025f); ;

    }
}
