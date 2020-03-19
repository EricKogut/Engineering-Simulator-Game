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
        spriteR.sprite = null;
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button");
        // TODO: 
        // - change the bullet type in the sprite renderer
        // - increase the damage done to enemies by bullets (Bullet Movement Script)
        spriteR.sprite = sprite;
    }
}
