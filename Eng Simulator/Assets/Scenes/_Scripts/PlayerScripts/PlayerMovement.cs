using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    public float playerSpeed;
    public ShootingAbility myAbility;
    private Vector2 currentDirection = new Vector2(1f, 0f);

    private BoxCollider2D playerBoxCollider;
    private Rigidbody2D playerRigidBody;
    private Vector3 movement;
    public static float energy = 100f;

    private Color original = new Color(255, 255, 255, 255);



    private Animator playerAnimation;


    static public PlayerMovement PM;
    // Start is called before the first frame update
    void Start()
    
    {
        if(PM == null){
            PM = this;
        }
        else{
            Debug.Log("Sorry, the Player Movement Script is being used elsewhere");
        }

        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //This will allow players to use abilities/shoot etc

        if (Input.GetButtonDown("Ability"))
        {
            myAbility.Ability(transform.position, currentDirection, playerAnimation, playerRigidBody);
        }

        if (Input.GetButtonDown("UltimateAbility"))
        {
            StartCoroutine("ActivateUltimate");

        }


        //movement = Vector2.zero;

        //Getting the horizontal axis
        //Getting the input from the user
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.magnitude > 0)
        {
            currentDirection = movement;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            playerAnimation.SetFloat("horizontalMovement", movement.x);
            playerAnimation.SetFloat("verticalMovement", movement.y);
            playerAnimation.SetBool("isMoving", true);
        }
        else
        {
            playerAnimation.SetBool("isMoving", false);
        }

        Movement();

        if (Input.GetKey("left shift") && energy > 0 && movement.magnitude > 0)
        {
            Sprinting();
            energy--;

        }
        else if (energy < 100)
        {
            energy = energy + 0.1f;
        }

        if (Input.GetKey("e") && energy > 50)
        {
            playerBoxCollider.enabled = false;
            playerRigidBody.AddForce(currentDirection * 10000);
            energy -= 50;
        }

        playerBoxCollider.enabled = true;
    }


    void Movement()
    {
        //Getting the position, adding change
        playerRigidBody.MovePosition(transform.position + movement.normalized * playerSpeed * Time.deltaTime);

        //I had to normalize the vector to make sure that the mvement is not faster moving diagonally

    }

    public IEnumerator AbilityEnum()
    {

        return null;
    }

    void Sprinting()
    {
        playerRigidBody.AddForce(currentDirection * 300);
    }

    IEnumerator ActivateUltimate()
    {
        playerAnimation.SetBool("ultimate", true);
        for (float i = 0.1f; i < 1; i += 0.2f)
        {
            //playerAnimation.Play("ultimateAbility");
            //playerAnimation.StopPlayback();
            for (float j = 0.1f; j < 1; j += 0.2f)
            {
                yield return new WaitForSeconds(0.05f);
                myAbility.Ability(transform.position, new Vector2(i, j), playerAnimation, playerRigidBody);
                myAbility.Ability(transform.position, new Vector2(-i, j), playerAnimation, playerRigidBody);
                myAbility.Ability(transform.position, new Vector2(i, -j), playerAnimation, playerRigidBody);
                myAbility.Ability(transform.position, new Vector2(-i, -j), playerAnimation, playerRigidBody);
            }

            //playerAnimation.StopPlayback();
            playerAnimation.SetBool("ultimate", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("You've been triggered");
        if (other.gameObject.CompareTag("enemy"))
        {
            SpriteRenderer spriteR = this.GetComponent<SpriteRenderer>();
            spriteR.color = original;
            this.GetComponent<PlayerHealthManager>().HurtPlayer(10);
            StartCoroutine(Flash());
            Debug.Log("You've been damaged");
        }
    }

    IEnumerator Flash()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        Color original = sr.color;
        sr.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sr.color = original;
    }
}
