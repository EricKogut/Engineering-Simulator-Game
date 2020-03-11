using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



public float playerSpeed;
public GenericAbility myAbility;
private Vector2 currentDirection = new Vector2(1f,0f);


private Rigidbody2D playerRigidBody;
private Vector3 movement;




private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //This will allow players to use abilities/shoot etc

        if(Input.GetButtonDown("Ability")){
            Debug.Log("This is a test");

            myAbility.Ability(transform.position, currentDirection, playerAnimation, playerRigidBody );

        }


        //Resetting the movement
        movement = Vector2.zero;

        //Getting the horizontal axis

            
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

        
        


     if(movement.magnitude>0){
        Movement();
        currentDirection = movement;
        playerAnimation.SetFloat("horizontalMovement",movement.x);
       
        playerAnimation.SetFloat("verticalMovement",movement.y);
     }
    }


    void Movement(){
        //Getting the position, adding change
        playerRigidBody.MovePosition(transform.position+movement.normalized*playerSpeed*Time.deltaTime);

        //I had to normalize the vector to make sure that the mvement is not faster moving diagonally

    }

    public IEnumerator AbilityEnum(){

        return null;
    }



}
