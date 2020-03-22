using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject bullet;
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = bullet.GetComponent<SpriteRenderer>();
        // On camera initialization, any changes to the top layer of the sprite are undone
        spriteR.sprite = null;
        bullet.GetComponent<BulletMovement>().damageDealt = 30; // resetting damage
    }

    // Update is called once per frame
    void Update()
    {

    }
}
