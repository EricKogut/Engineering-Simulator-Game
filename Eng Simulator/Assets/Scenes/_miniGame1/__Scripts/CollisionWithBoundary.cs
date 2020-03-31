using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionWithBoundary : MonoBehaviour
{

    public int myScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("right") || other.CompareTag("left") || other.CompareTag("bottom"))
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("player"))
        { 
            Destroy(this.gameObject);
            SceneManager.LoadScene(myScene, LoadSceneMode.Single);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
