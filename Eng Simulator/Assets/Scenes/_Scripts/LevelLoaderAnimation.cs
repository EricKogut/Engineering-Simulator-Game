using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderAnimation : MonoBehaviour
{
    public Animator transition;
    public int sceneNumber;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D theCollider)
    {

        LoadNextLevel();


    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(sceneNumber));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);



    }

    
}
