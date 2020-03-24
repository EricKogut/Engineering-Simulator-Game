using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : StateMachineBehaviour
{
    //This will represent the player position
    private Transform currentPosition;
    public float speed;
    private Animator animationVariable;
    private Vector2 movement;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentPosition = GameObject.FindGameObjectWithTag("player").transform;
        animationVariable = animator;


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    //Acts as the update function
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (GameObject.Find("Player Variant"))
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, currentPosition.position, speed * Time.deltaTime);
        }

        movement = currentPosition.position;

        //Note: had to normalize the variables since the numbers didnt work great with the animator
        animationVariable.SetFloat("horizontalMovement", (movement.normalized.x));
        animationVariable.SetFloat("verticalMovement", (movement.normalized.y));



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationVariable.SetFloat("horizontalMovement", (movement.normalized.x));
        animationVariable.SetFloat("verticalMovement", (movement.normalized.y));
    }









    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
