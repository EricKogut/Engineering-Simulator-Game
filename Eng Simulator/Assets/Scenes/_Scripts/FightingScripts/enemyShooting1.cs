using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting1 : MonoBehaviour
{

    private Transform currentPosition;
    private ShootingAbility primaryAbility;
    new Vector3 currentDirection;
    public GameObject myObject;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
          InvokeRepeating("Shooting", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = GameObject.FindGameObjectWithTag("player").transform;
        currentDirection = currentPosition.position-transform.position;

    }



  //Ultimate Ability IEnumeration method
  void Shooting()
    //void Shooting()
    {
        
        
        //Starting by creating the projectilek
        //Looking at where the player is facing
        float direction = Mathf.Atan2(currentDirection.y, currentDirection.x);

         //Instantiating the object with regards to where the player is facing
        GameObject newObject = Instantiate(myObject, transform.position + currentDirection.normalized*3, Quaternion.Euler(0f, 0f, direction));


    BulletMovementEnemy movement = newObject.GetComponent<BulletMovementEnemy>();
        if (movement)
        {
            movement.movement(currentDirection);
        }
    

   
    }



}
