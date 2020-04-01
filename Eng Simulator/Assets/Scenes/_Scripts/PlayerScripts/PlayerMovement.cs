using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    //Variables to describe the player
    public float playerSpeed;
    public ShootingAbility primaryAbility;
    private Vector2 currentDirection = new Vector2(1f, 0f);


    private BoxCollider2D playerBoxCollider;
    private Rigidbody2D playerRigidBody;
    private Vector3 movement;
    private static int experience = 0; // player always starts with 0 experience
    public static float energy = 100f;

    private Color original;


    private Animator playerAnimation;

    [System.Serializable]
    public struct NumberMap
    {
        public int year;
        public int exp;
    }
    public NumberMap[] dictionary; // a type of hash table using the NumberMap structure

    static public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()

    {

        if (playerMovement == null)
        {
            playerMovement = this;
        }
        else
        {
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
            primaryAbility.Ability(transform.position, currentDirection, playerAnimation, playerRigidBody);
        }

        if (Input.GetButtonDown("UltimateAbility"))
        {
            StartCoroutine("ActivateUltimate");
        }

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
            playerBoxCollider.enabled = true;
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
                primaryAbility.Ability(transform.position, new Vector2(i, j), playerAnimation, playerRigidBody);
                primaryAbility.Ability(transform.position, new Vector2(-i, j), playerAnimation, playerRigidBody);
                primaryAbility.Ability(transform.position, new Vector2(i, -j), playerAnimation, playerRigidBody);
                primaryAbility.Ability(transform.position, new Vector2(-i, -j), playerAnimation, playerRigidBody);
            }

            //playerAnimation.StopPlayback();
            playerAnimation.SetBool("ultimate", false);
        }
    }
    void SetColor()
    {
        if (ButtonManager.original)
        {
            original = new Color(255, 255, 255);
        }
        else if (ButtonManager.mechanical)
        {
            original = Color.blue;
        }
        else
        {
            original = Color.green;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("You've been triggered");
        if (other.gameObject.CompareTag("enemy"))
        {
            SpriteRenderer spriteR = this.GetComponent<SpriteRenderer>();
            SetColor();
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

    public int Experience
    { // Experience property exposes private field for usage by other scripts
        get
        {
            return experience;
        }
        set
        {
            experience += value;
        }
    }

    public int Level
    {
        get
        {
            foreach (NumberMap entry in dictionary)
            {
                if ((Experience - entry.exp) < 0) return entry.year; // Only when the player's experience is greater than the required
            }              // experience to enter that year is he admitted.
            return 5;
        }
        // no setter as this is never manipulated manually
    }
}
