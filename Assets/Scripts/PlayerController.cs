using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private const string PLAYER_IS_WALKING = "isWalking";
    [SerializeField] private float moveSpeed = 15f;
    private float horizontalAxis;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Player starts at position x: -8.75 and y: -2.38

    private void Update() {
        horizontalAxis = Input.GetAxisRaw("Horizontal");

        if (horizontalAxis < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else if(horizontalAxis > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);


        animator.SetBool(PLAYER_IS_WALKING, horizontalAxis != 0);
    }

    private void FixedUpdate() {
        rb2d.velocity = new Vector2(horizontalAxis * moveSpeed, rb2d.velocity.y);
    }

    public void PlayFootstepSound() {
        int footstepID = Random.Range(0, AudioManager.Ins.Footsteps.Length);

        AudioManager.Ins.PlaySFXOnce(AudioManager.Ins.Footsteps[footstepID]);
    }
}
