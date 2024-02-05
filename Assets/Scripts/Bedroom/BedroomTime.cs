using UnityEngine;

public class BedroomTime : MonoBehaviour {
    [SerializeField] private Sprite bedroomDay;
    [SerializeField] private Sprite bedroomNight;
    private SpriteRenderer spriteRenderer;

    //TODO: Change bedroom look depending on time of day

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetDaytime() {
        spriteRenderer.sprite = bedroomDay;
        BedroomAmbience.Ins.SetAmbience(BedroomAmbience.Ins.DayAmbience);
    }

    public void SetNighttime() {
        spriteRenderer.sprite = bedroomNight;
        BedroomAmbience.Ins.SetAmbience(BedroomAmbience.Ins.NightAmbience);
    }
}
