//Importing the necessary stuff
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Scripts/Abilities/ShootingAbility", fileName = "Shooting Ability")]


//Projectile will inherit from Generic ability
public class ShootingAbility : GenericAbility
{
    [SerializeField]
    private GameObject myObject;


    public override void Ability(Vector2 playerPosition, Vector2 currentDirection,
           Animator playerAnimator, Rigidbody2D playerRB = null)
    {

        //Starting by creating the projectilek
        //Looking at where the player is facing
        float direction = Mathf.Atan2(currentDirection.y, currentDirection.x);

        //Instantiating the object with regards to where the player is facing
        GameObject newObject = Instantiate(myObject, playerPosition, Quaternion.Euler(0f, 0f, direction));

        BulletMovement movement = newObject.GetComponent<BulletMovement>();
        if (movement)
        {
            movement.movement(currentDirection);
        }

    }
}

