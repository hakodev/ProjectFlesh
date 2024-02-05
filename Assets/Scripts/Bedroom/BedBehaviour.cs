using UnityEngine;

public class BedBehaviour : MonoBehaviour {
    [SerializeField] private Sprite bedEmpty;
    [SerializeField] private Sprite bedKid;
    private SpriteRenderer spriteRenderer;

    //TODO: Change bed sprite depending on whether the player is sleeping or not

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GetUp() {
        spriteRenderer.sprite = bedEmpty;
    }

    public void Sleep() {
        spriteRenderer.sprite = bedKid;
    }
}
