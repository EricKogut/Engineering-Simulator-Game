using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{

    private Transform currentPosition;
    public ShootingAbility primaryAbility;
    new Vector3 currentDirection;
    private GameObject myObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = GameObject.FindGameObjectWithTag("player").transform;
        currentDirection = currentPosition.position-transform.position;
    Debug.Log(currentDirection);
        //Starting the couroutine
            StartCoroutine("Shooting");
    }



  //Ultimate Ability IEnumeration method
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(0.05f);
        primaryAbility.Ability(transform.position + currentDirection.normalized, currentDirection, null, null);

        
        //Starting by creating the projectilek
        //Looking at where the player is facing
        float direction = Mathf.Atan2(currentDirection.y, currentDirection.x);

         //Instantiating the object with regards to where the player is facing
        GameObject newObject = Instantiate(transform.position + currentDirection.normalized, playerPosition, Quaternion.Euler(0f, 0f, direction));

        BulletMovement movement = newObject.GetComponent<BulletMovement>();
        if (movement)
        {
            movement.movement(currentDirection);
        }

   
    }



}
