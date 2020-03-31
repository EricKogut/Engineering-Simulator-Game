using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{

    private Transform currentPosition;
    public ShootingAbility primaryAbility;
    new Vector3 currentDirection;

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
   
    }



}
