using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{

    public int myScene;

    public void OnTriggerEnter2D(Collider2D theCollider)
    {

        SceneManager.LoadScene(myScene, LoadSceneMode.Single);
        Debug.Log("Hello It Worked");
      



    }




}
