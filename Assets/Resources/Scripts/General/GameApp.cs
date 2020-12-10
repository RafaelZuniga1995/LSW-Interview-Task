using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    public static GameApp singleton;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal CameraManager getCameraManager()
    {
        return cameraManager.GetComponent<CameraManager>();
    }
}
