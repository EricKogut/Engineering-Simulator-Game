using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HideButton : MonoBehaviour
{ // this script should be moved to the panel (take an array of GameObjects for multiple buttons)
    public GameObject player;
    public GameObject textBox;

    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = false; // button initially cannot be interacted with
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerXP>().Level >= 1)
        {
            textBox.SetActive(false); // getting rid of textBox with message to play more
            startButton.interactable = true; // button may now be clicked
        }
    }
}
