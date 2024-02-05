using UnityEngine;

public class ChairBehaviour : MonoBehaviour {
    [SerializeField] private Sprite chairEmpty;
    [SerializeField] private Sprite chairKid;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //TODO: Change chair sprite depending on whether the player is sitting or not
}
