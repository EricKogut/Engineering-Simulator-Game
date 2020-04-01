using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;


    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 6f;

    private checkBounds bndCheck;

    // Start is called before the first frame update
    void Awake()
    {
        //initiates the singleton
        S = this;
        //sets the bndCheck to the checkBounds script that is a component of the camera
        bndCheck = GetComponent<checkBounds>();
        //starts the spawn enemy method and spawns the ever second
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        //sets which enemy will spawn
        int ndx = Random.Range(0, prefabEnemies.Length);

        //sets the game object which will be the enemy that will instantiated
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);
        //gives a padding to the enemy that is spawned
        float enemyPadding = enemyDefaultPadding;
        //checks the bounds of the enemy
        if (go.GetComponent<checkBounds>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<checkBounds>().radius);
        }
        //sets the current position of the enemy to be 0
        Vector3 pos = Vector3.zero;
        //gives the camera the bounds
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        // spawns the enemy at a random range within the camera bounds set earlier
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        //sets the position of the enemy to the new position
        go.transform.position = pos;
        //calls the function again recursively
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }

    public void Update()
    {
        //this will update the time delay between the spawning of ducks to increase the difficulty for the player

        enemySpawnPerSecond += 0.0005f;
    }
}
