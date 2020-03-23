using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    private SpriteRenderer spriteR;
    private Color defaultColor = new Color(255, 255, 255);
    // Start is called before the first frame update
    void Start()
    {
        spriteR = bullet.GetComponent<SpriteRenderer>();
        // On camera initialization, any changes to the top layer of the sprite are undone
        spriteR.sprite = null;
        bullet.GetComponent<BulletMovement>().damageDealt = 30; // resetting damage
        player.GetComponent<SpriteRenderer>().color = defaultColor;
        player.GetComponent<PlayerMovement>().playerSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
