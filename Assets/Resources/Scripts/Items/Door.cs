using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public BoxCollider2D newCameraBounds;
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
        Debug.Log("Door.OnTriggerEnter2D() | collision.name: " + collision.name);

        // Player entered store
        Transform spawnPosition = transform.Find("SpawnPosition");
        GameApp.singleton.player.transform.position = spawnPosition.position;
        GameApp.singleton.getCameraManager().setCameraBounds(newCameraBounds);
    }
}
