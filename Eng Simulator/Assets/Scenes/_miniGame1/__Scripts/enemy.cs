using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    //sets the speed and movement direction
    [Header("Set in the Inspector: Enemy")]
    public float speed = 10f;
    public bool moveDir = false;

    //creates a new checkBound instance class that is specific to the object 
    private checkBounds bndCheck;

    
    public void Start()
    {
        //determines which way the new object will move
        moveDir = (Random.value >= 0.5f);
        //adds a bound check to bndCheck that has been initialized
        bndCheck = GetComponent<checkBounds>();
    }

    //basic vector3 field
    public Vector3 pos
    {
        get {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    public virtual void Move()
    {
        //if the tag of the object is Enemy1 it will move only downwards 
        if(this.gameObject.tag == "Enemy1")
        {
            Vector3 tempPos = pos;
            //sets the position of the enemy to slowly move downwards as a function of time
            tempPos.y -= speed * Time.deltaTime;
            pos = tempPos;
        }
        //otherwise it will move diagonally
        else
        {
            Vector3 tempPos = pos;
            //moves down with respect to time
            tempPos.y -= speed * Time.deltaTime;
            //moves to the left with respect to time
            if(moveDir)
            {

                    tempPos.x += speed * Time.deltaTime;               
            }
            //moves to the right with respect to time
            else if(!moveDir)
            {                              
                    tempPos.x -= speed * Time.deltaTime;                   
            }
            //the postion is then set to the temporary position currently made
            pos = tempPos;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the enemy collides with the Hero "spaceShip" both will be destroyed and the game will end
        if (collision.gameObject.tag == "Hero")
        {

            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
            restart();
        }
    }

    void restart()
    {
        //this will restart the scene once it is invoked
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Update is called once per frame
    void Update()
    {
        //runs the move method to add movement to the enemy
        Move();
        //checks in case the enemy goes off the screen will delete it
        if(bndCheck != null && (bndCheck.offDown||bndCheck.offLeft||bndCheck.offRight) )
        {
            Destroy(gameObject);
        }
    }
}
