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
            player.GetComponent<PlayerMovement>().Experience = 1000;
            Destroy(gameObject);
        }
        else{
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
