using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementEnemy : MonoBehaviour
{


    public int damageDealt = 30;

    //This rigidBody will be what the builder
    public Rigidbody2D theRigidBody;
    int counter = 0;

    //The speed will control 
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the RB component
        theRigidBody = GetComponent<Rigidbody2D>();
    }

 

    //This will actually move the bullet
    public void movement(Vector2 direction)
    {
        theRigidBody.velocity = direction.normalized * speed;
        Debug.Log(theRigidBody.velocity);
        Debug.Log("RAN");
      
 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            //            Destroy(other.gameObject);
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageDealt);
            Destroy(this.gameObject);
            // TODO: add player XP each time an enemy is killed
        }
        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
