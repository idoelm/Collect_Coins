using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 500f;
    [SerializeField] private float jumpForce = 8.0f;

    public TextMeshProUGUI scoreText;
    private int Score = 0;

    private bool isGrounded;
    private Rigidbody2D rigidBody;
    private float deltaX;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            Debug.LogError($"Failed to start. {rigidBody.GetType()} not found!");
        }
        isGrounded = true;
        scoreText.text = "Score " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        deltaX = Input.GetAxis("Horizontal");

        movement = new Vector2(deltaX * speed * Time.fixedDeltaTime, rigidBody.velocity.y);

        rigidBody.velocity = movement;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Ground();

        }
        if (collision.gameObject.tag.Equals("Coin"))
        {
            Destroy(collision.gameObject);
            Score++;
            Debug.Log(Score);
            scoreText.text = "Score " + Score;
        }


        if (collision.gameObject.tag.Equals("Cup"))
        {
            SceneManager.LoadScene("Victory");

        }

    }



    void Ground()
    {
        isGrounded = true;
    }
}
