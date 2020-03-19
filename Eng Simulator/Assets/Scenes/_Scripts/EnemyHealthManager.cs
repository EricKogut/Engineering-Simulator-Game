using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject player;
    public int enemyMaxHealth;
    public int enemyCurrentHealth;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            player.GetComponent<PlayerXP>().Experience = 1000;
            Debug.Log("You've earned some experience");
            Destroy(gameObject);
        }
        else{
            Debug.Log("bruh");
        }
    }

    public void HurtEnemy(int dmg)
    {
        enemyCurrentHealth -= dmg;

    }

    public void SetMaxHealth(int max)
    {
        enemyMaxHealth = max;
    }

}
