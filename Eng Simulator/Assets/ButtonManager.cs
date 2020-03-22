using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject bullet;
    public Button myButton;

    // private fields
    private SpriteRenderer spriteR;
    private Sprite sprite;
    // Start is called before the first frame update
    void Awake()
    {
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        spriteR = bullet.GetComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("Gear");
    }

    void TaskOnClick()
    {
        spriteR.sprite = sprite;
        bullet.GetComponent<BulletMovement>().damageDealt = 50; // increasing damage through BulletMovement script
    }
}
