using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{

    public string myScene;

    public void collision(Collider2D theCollider)
    {   

        if(theCollider.CompareTag("Player") && !theCollider.isTrigger){

            SceneManager.LoadScene(myScene);
        }



    }




}
