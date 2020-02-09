using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    public Rigidbody2D theRigidBody;
    
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
    theRigidBody = GetComponent<Rigidbody2D>();  
    }

    public void movement(Vector2 direction){
        theRigidBody.velocity = direction.normalized*speed;
        Debug.Log("MOVINGS");
        Debug.Log(direction);
    }
}
