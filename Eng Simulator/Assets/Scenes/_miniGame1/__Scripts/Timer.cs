using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //intialization of all the variables including currentTime and startingTime
    public float currentTime = 0f;
    public float startingTime = 100f;
    public int myScene;
    public GameObject player;
    

    //countdownText  field for the UI field
    [SerializeField] Text countdownText;

    private void Start()
    {
        currentTime = startingTime;

    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            player.GetComponent<PlayerMovement>().Experience = 3000;
            countdownText.text = "Finished the Level Congrats Time to go fight the BOSS";
            SceneManager.LoadScene(myScene, LoadSceneMode.Single);
        }
    }

}
