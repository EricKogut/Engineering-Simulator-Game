 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : StateMachineBehaviour
{
    GameObject NPC;
    GameObject[] locations;
    int currentLocation;


    void Awake(){
        locations = GameObject.FindGameObjectsWithTag("location");
    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        currentLocation = 0;
       
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(Vector3.Distance(locations[currentLocation].transform.position, NPC.transform.position)<3.0f){
           currentLocation++;
           if(currentLocation >= locations.Length){
               currentLocation =0;
           }
       }

        var direction = locations[currentLocation].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, NPC.transform.rotation,   1.0f*Time.deltaTime);

        //NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,Quaternion.LookRotation(direction),0);


        NPC.transform.Translate(0,0,Time.deltaTime*2.0f);

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }


}
