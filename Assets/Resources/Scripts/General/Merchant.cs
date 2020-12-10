using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] public GameObject interactSign;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactSign.SetActive(true);
        WidgetManager.singleton.setCurrentInteractSign(interactSign);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactSign.SetActive(false);
        WidgetManager.singleton.setCurrentInteractSign(null);
    }
}