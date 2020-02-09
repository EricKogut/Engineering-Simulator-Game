using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//References for objects

[CreateAssetMenu(menuName ="Scripts/Abilities/GenericAbility", fileName = "New Generic Ability")]



public class GenericAbility : ScriptableObject
{
    public virtual void Ability(Vector2 playerPosition, Vector2 currentDirection, Animator playerAnimator, 
    Rigidbody2D playerRB = null)
    {


    } 

}

