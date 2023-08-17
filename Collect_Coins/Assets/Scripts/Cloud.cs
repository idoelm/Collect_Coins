using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private void Start()
    {
        // Schedule the destruction of the cloud after 10 seconds
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Invoke("DestroyCloud", 400f);
        
    }

    private void DestroyCloud()
    {
        Destroy(gameObject);
    }
}
