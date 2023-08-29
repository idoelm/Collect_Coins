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

    private bool isJump;
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
        scoreText.text = "Score " + Score;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void Update()
    {
        deltaX = Input.GetAxis("Horizontal");
        movement = new Vector2(deltaX * speed * Time.fixedDeltaTime, rigidBody.velocity.y);
        rigidBody.velocity = movement;
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
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
}
