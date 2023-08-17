using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thorns : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag.Equals("Player"))
        {
            //  Debug.Log("Player");
            SceneManager.LoadScene("Game Over");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
