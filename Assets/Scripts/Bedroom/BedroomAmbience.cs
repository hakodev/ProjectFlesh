using UnityEngine;

public class BedroomAmbience : MonoBehaviour {
    // Making it a singleton for now, if the mechanic is implemented some other way,
    // make it a regular class (delete lines 6 and 14-19)
    public static BedroomAmbience Ins { get; private set; }
    [field: SerializeField] public Sprite DayAmbience { get; }
    [field: SerializeField] public Sprite NightAmbience { get; }
    private SpriteRenderer spriteRenderer;

    //TODO: Change bedroom ambience depending on time of day

    private void Awake() {
        if(Ins == null) {
            Ins = this;
        } else if(Ins != this) {
            Destroy(this.gameObject);
            return;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAmbience(Sprite ambienceSprite) {
        spriteRenderer.sprite = ambienceSprite;
        Color temp = spriteRenderer.color;

        if(ambienceSprite == DayAmbience) {
            temp.a = 0.1960784f;
            spriteRenderer.color = temp;
        } else {
            temp.a = 1f;
            spriteRenderer.color = temp;
        }
    }
}
