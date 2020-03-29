using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //this is the UI element that will display the time
    [SerializeField] public Text uiText;
    [SerializeField] public float mainTimer;

    //these are the private and public variables that are responsible for keeping time
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public int myScene;


    //upon start this timer will be qeued and ready to begin
    void Start()
    {
        timer = mainTimer;    
    }

    // Update is called once per frame
    void Update()
    {
        //if the timer is still greater than 0 it will proceed as is
        if(timer>=0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");

        }
        //if the timer is less than 0 it will be game over and seb will be reloaded
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            GameOver();
        }
        
    }
    //switches back to seb once the timer is up
    void GameOver()
    {
        SceneManager.LoadScene(myScene, LoadSceneMode.Single);
    }
}
