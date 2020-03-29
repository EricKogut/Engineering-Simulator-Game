using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("right") || other.CompareTag("left") || other.CompareTag("bottom"))
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
