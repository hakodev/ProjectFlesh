using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float wallJumpForce;
    private float horizontalAxis;
    private bool jumpPressed;
    private int jumpsRemaining;
    private bool isGrounded;
    private bool isTouchingWall;
    private const int maxJumps = 2;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        jumpsRemaining = maxJumps;
    }

    private void Update() {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetButtonDown("Jump");

        if(jumpPressed) {
            if(!isGrounded && isTouchingWall) {
                WallJump();
            } else if(isGrounded || jumpsRemaining > 0) {
                Jump();
            }
        }
    }

    private void FixedUpdate() {
        rb2d.velocity = new Vector2(horizontalAxis * moveSpeed, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            jumpsRemaining = maxJumps;
        } else if(collision.gameObject.CompareTag("Wall")) {
            isTouchingWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
        if(collision.gameObject.CompareTag("Wall")) {
            isTouchingWall = false;
        }
    }

    private void Jump() {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0f); // Zero out the vertical velocity before jump
        rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        jumpsRemaining--;
    }

    private void WallJump() {
        rb2d.velocity = new Vector2(0f, 0f); // Zero out the velocity before wall jump
        rb2d.AddForce(new Vector2(-horizontalAxis * wallJumpForce, jumpForce), ForceMode2D.Impulse);
        jumpsRemaining = maxJumps - 1;
    }
}
