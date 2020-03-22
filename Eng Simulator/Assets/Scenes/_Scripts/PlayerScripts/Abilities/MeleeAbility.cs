using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbility : MonoBehaviour
{
    public GameObject myObject;
    public float radius;
    public Transform currentPosition;
    public LayerMask enemy;

    void Update(){
        if(Input.GetButtonDown("MeleeAbility")){
            Collider2D[] listOfEnemies = Physics2D.OverlapCircleAll(currentPosition.position, radius, enemy );
            Debug.Log("Activated");
            if(listOfEnemies.Length>0){
                for (int i = 0; i < listOfEnemies.Length; i++)
                {
                print(listOfEnemies[i].GetComponent<EnemyHealthManager>().enemyCurrentHealth);
                listOfEnemies[i].GetComponent<EnemyHealthManager>().enemyCurrentHealth -=10;
                }
            }
        
        
        }
    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;    
        Gizmos.DrawWireSphere(currentPosition.position, radius);
    }

}
