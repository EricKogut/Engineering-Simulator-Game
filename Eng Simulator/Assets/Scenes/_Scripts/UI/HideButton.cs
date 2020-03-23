using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HideButton : MonoBehaviour
{ // this script should be moved to the panel (take an array of GameObjects for multiple buttons)
    public GameObject player;
    public GameObject textBox;
    public Button[] buttonArray = new Button[2]; // Button array permits dynamic change of number of buttons
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in buttonArray)
        {
            if (button != null)
                button.interactable = false; // accessing each button contained in the array, setting it as non-interactable
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().Level >= 1 && textBox != null)
        {
            textBox.SetActive(false); // getting rid of textBox with message to play more
            foreach (Button button in buttonArray)
            {
                button.interactable = true; // making buttons interactable to user after Level 1 is reached
            }

        }
    }
}
