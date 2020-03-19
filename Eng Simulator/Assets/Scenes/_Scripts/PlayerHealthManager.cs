using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    // Start is called before the first frame update

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            this.gameObject.SetActive(false); // Inactivity instead of destruction avoids problems with PlayerMovement script checking the Object transform
        }
    }

    public void HurtPlayer(int dmg)
    {
        playerCurrentHealth -= dmg;

    }

    public void SetMaxHealth(int max)
    {
        playerMaxHealth = max;
    }

}
