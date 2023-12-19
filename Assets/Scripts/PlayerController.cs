using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float horizontalAxis;
    private bool jumpPressed;
    private bool isGrounded;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetButtonDown("Jump");
        if(jumpPressed && isGrounded) {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate() {
        rb2d.velocity = new Vector2(horizontalAxis * moveSpeed, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
