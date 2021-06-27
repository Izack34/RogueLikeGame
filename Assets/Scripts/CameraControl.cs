using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform Player;

    float camX = -12;
    float camY = -12;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        camX += Input.mouseScrollDelta.y;
        camY += Input.mouseScrollDelta.y; 
        camX = Mathf.Clamp(camX, -14, -3);
        camY = Mathf.Clamp(camY, -14, -3);
        //need clamp  
        transform.position = Player.position - new Vector3(camX,camY,0f);
    }
}
