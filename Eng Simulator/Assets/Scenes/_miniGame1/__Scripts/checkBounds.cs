using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBounds : MonoBehaviour
{
    [Header("Set in Inspector")]

    public float radius = 1f;
    public bool keepOnScreen = false;

    [Header("Set Dynamically")]
    public float camWidth= 0.0f;
    public float camHeight = 0.0f;
    public bool isOnScreen = true;

    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    // Start is called before the first frame update
    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //sets a vector to the position of the current object
        Vector3 viewPos = transform.position;
        //shows if the object in on screen
        isOnScreen = true;
        //sets all of the bounds to be true
        offRight = offLeft = offUp = offDown = false;
        //if the object goes off the right side this will be triggered and the bounds check will be set to false for that instance
        if (viewPos.x > camWidth - radius)
        {
            viewPos.x = camWidth - radius;
            offRight = true;
           

        }
        //if the object goes off the left side this will be triggered and the bounds check will be set to false for that instance
        if (viewPos.x < -camWidth + radius)
        {
            viewPos.x = -camWidth + radius;
            offLeft = true;
        }
        //if the object goes off the top side this will be triggered and the bounds check will be set to false for that instance
        if (viewPos.y > camHeight - radius)
        {
            viewPos.y = camHeight - radius;
            offUp = true;
        }
        //if the object goes off the bottom side this will be triggered and the bounds check will be set to false for that instance
        if (viewPos.y<-camHeight + radius)
        {
            viewPos.y = -camHeight + radius;
            offDown = true;
        }
        //if it has gone off the screen anywhere it will set the isOnScreen property to false
        isOnScreen = !(offRight || offLeft || offUp || offDown);

        //this is to keep the object on the screen
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = viewPos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }

        transform.position = viewPos;
    }

    //sets the bounds of the camera and area where it is ok to move
    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
    
}
