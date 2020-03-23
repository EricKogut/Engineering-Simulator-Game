using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    //    public Button myButton;
    public Button[] buttonArray = new Button[2];

    // private fields
    private SpriteRenderer spriteR;
    private Sprite sprite;

    public static bool original = true;
    public static bool mechanical = false;

    // Start is called before the first frame update
    void Awake()
    {
        //        Button btn = myButton.GetComponent<Button>();
        foreach (Button button in buttonArray)
        {

            if (button.name == "MechanicalButton")
            {
                button.onClick.AddListener(MechanicalTaskOnClick);
            }
            else
            {
                button.onClick.AddListener(ChemicalTaskOnClick);
            }
        }
    }
    void DisableButtons()
    {
        foreach (Button button in buttonArray)
        {
            button.interactable = false;
        }
    }
    void MechanicalTaskOnClick()
    {
        player.GetComponent<SpriteRenderer>().color = Color.blue;
        spriteR = bullet.GetComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("Gear");
        spriteR.sprite = sprite;
        bullet.GetComponent<BulletMovement>().damageDealt = 50; // increasing damage through BulletMovement script
        original = false;
        mechanical = true;
        DisableButtons();
    }
    void ChemicalTaskOnClick()
    {
        spriteR = player.GetComponent<SpriteRenderer>();
        spriteR.color = Color.green;
        player.GetComponent<PlayerMovement>().playerSpeed = 16;
        original = false;
        mechanical = false;
        DisableButtons();
    }
}