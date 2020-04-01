using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    //Variables to describe the player
    public float playerSpeed;
    public ShootingAbility primaryAbility;
    private Vector2 _currentDirection = new Vector2(1f, 0f);
    private BoxCollider2D _playerBoxCollider;
    private Rigidbody2D _playerRigidBody;
    private Vector3 _movement;
    private Animator _playerAnimation;

    //Static  variables to be used by other scrips as well
    private static int experience = 0; 
    public static float energy = 100f;

    //Crating a color variable to be used to change the color of the player
    private Color _original;

    //static variable to describe the script
    static public PlayerMovement playerMovement;



//////////////////////////////////////////////////////////////////////////////////////////////



    [System.Serializable]
    public struct NumberMap
    {
        public int year;
        public int exp;
    }
    public NumberMap[] dictionary; // a type of hash table using the NumberMap structure

    // Start is called before the first frame update
    void Start(){


        //instantiating the static playermovement singleton if it does not already exist
        if (playerMovement == null)
        {
            playerMovement = this;
        }

        else{Debug.Log("Sorry, the Player Movement Script is being used elsewhere");}


        //Getting the components of the palyer
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<Animator>();
        _playerBoxCollider = GetComponent<BoxCollider2D>();
    }


//////////////////////////////////////////////////////////////////////////////////////////////


    // Update is called once per frame
    void FixedUpdate()
    {

        //Thees will check to see if the palyer would like to use abilities/shoot etc

        //Shooting
        if (Input.GetButtonDown("Ability"))
        {
            primaryAbility.Ability(transform.position, _currentDirection, _playerAnimation, _playerRigidBody);
        }

        //Ultimate coroutine
        if (Input.GetButtonDown("UltimateAbility"))
        {
            //Starting the couroutine
            StartCoroutine("ActivateUltimate");
        }


        //Getting the input from the user
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        //If the player has moved, run this
        if (_movement.magnitude > 0)
        {
            _currentDirection = _movement;
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            _playerAnimation.SetFloat("horizontalMovement", _movement.x);
            _playerAnimation.SetFloat("verticalMovement", _movement.y);
            _playerAnimation.SetBool("isMoving", true);
        }


        //Otherwise set the animation variable to false
        else{_playerAnimation.SetBool("isMoving", false);}


        //Calling the movement script
        Movement();



        //Shift input -> Sprint command
        if (Input.GetKey("left shift") && energy > 0 && _movement.magnitude > 0)
        {
            Sprinting();
            energy--; //Lowering the energy value of the player
        }

        //Adding energy if the energy is under 100
        else if (energy < 100)  {energy = energy + 0.1f;}

        //e input -> dash ability
        if (Input.GetKey("e") && energy > 20)
        {
            _playerRigidBody.AddForce(_currentDirection * 10000);
            energy -= 20; // This ability removes 20 energy per use
        }

    }


///////////////////////////////////////////////////////////////////////////////////////////////

//The following are helper methods for the code used above



    //Movement Script when player uses wasd
    void Movement()
    {
        //Getting the position, adding change
        _playerRigidBody.MovePosition(transform.position + _movement.normalized * playerSpeed * Time.deltaTime);
    }

    //Sprinting script when player presses shift
    void Sprinting()
    {
        _playerRigidBody.AddForce(_currentDirection * 300);
    }


    //Ultimate Ability IEnumeration method
    IEnumerator ActivateUltimate()
    {

        //Settig the ultimate ability animation to be true
        _playerAnimation.SetBool("ultimate", true);

        //Using for loops to generate bullets
        for (float i = 0.1f; i < 1; i += 0.2f)
        {
            for (float j = 0.1f; j < 1; j += 0.2f)
            {
                //Waiting in between bullets
                yield return new WaitForSeconds(0.05f);
                primaryAbility.Ability(transform.position, new Vector2(i, j), _playerAnimation, _playerRigidBody);
                primaryAbility.Ability(transform.position, new Vector2(-i, j), _playerAnimation, _playerRigidBody);
                primaryAbility.Ability(transform.position, new Vector2(i, -j), _playerAnimation, _playerRigidBody);
                primaryAbility.Ability(transform.position, new Vector2(-i, -j), _playerAnimation, _playerRigidBody);
            }

            //Stopping the player animation
            _playerAnimation.SetBool("ultimate", false);
        }
    }



    //Setting the color of the player based on what the player chooses with regards to their discipline
    void SetColor()
    {
        if (ButtonManager.original)
        {
            _original = new Color(255, 255, 255);
        }
        else if (ButtonManager.mechanical)
        {
            _original = Color.blue;
        }
        else
        {
            _original = Color.green;
        }
    }


    //Checking if the player has collided with an enemy
    void OnTriggerEnter2D(Collider2D other)
    {

        //If it does the script will change the color of the sprite and damage the player
        if (other.gameObject.CompareTag("enemy"))
        {
            SpriteRenderer spriteR = this.GetComponent<SpriteRenderer>();
            SetColor();
            spriteR.color = _original;
            this.GetComponent<PlayerHealthManager>().HurtPlayer(10);

            //Flashing the color red, and returning the color to the original
            StartCoroutine(Flash());
        }
    }


    //Method to return the color of the sprite to the oroginal color
    IEnumerator Flash()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        Color _original = sr.color;
        sr.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sr.color = _original;
    }


    //Get + set for experience property
    public int Experience
    {
        get{return experience;}
        set{experience += value;}
    }

    //Get + set for the level property
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
