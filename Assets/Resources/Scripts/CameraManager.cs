using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float x, y, finalX, finalY;
    [SerializeField] public GameObject mainCamera;
    [SerializeField] Transform cameraBounds;
    [SerializeField] BoxCollider2D camBoundsBox2D;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        finalX = GameApp.singleton.player.transform.position.x;
        finalY = GameApp.singleton.player.transform.position.y;
        x += (finalX - x) * Cons.TWEEN;
        y += (finalY - y) * Cons.TWEEN;


        var vertExtent = mainCamera.GetComponent<Camera>().orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        //x = Mathf.Clamp(x, cameraBounds.GetComponent<Renderer>().bounds.min.x + mainCamera.GetComponent<Camera>().orthographicSize,
        //  cameraBounds.GetComponent<Renderer>().bounds.max.x - mainCamera.GetComponent<Camera>().orthographicSize / 2);


        x = Mathf.Clamp(x, camBoundsBox2D.bounds.min.x + horzExtent,
            camBoundsBox2D.bounds.max.x - horzExtent);


        y = Mathf.Clamp(y, camBoundsBox2D.bounds.min.y + vertExtent,
            camBoundsBox2D.bounds.max.y - vertExtent);

        mainCamera.transform.position = new Vector3(x, y + 0, - 10);
    }
}
