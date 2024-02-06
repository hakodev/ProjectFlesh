using UnityEngine;

public class TimeOfDay : MonoBehaviour {
    [SerializeField] private Sprite bedroomDay;
    [SerializeField] private Sprite bedroomNight;
    [SerializeField] private Sprite kitchenDay;
    [SerializeField] private Sprite kitchenNight;
    [SerializeField] private SpriteRenderer bedroomSpriteRenderer;
    [SerializeField] private SpriteRenderer kitchenSpriteRenderer;

    //TODO: Change bedroom look depending on time of day

    public void SetDaytime() {
        bedroomSpriteRenderer.sprite = bedroomDay;
        kitchenSpriteRenderer.sprite = kitchenDay;
    }

    public void SetNighttime() {
        bedroomSpriteRenderer.sprite = bedroomNight;
        kitchenSpriteRenderer.sprite = kitchenNight;
    }
}
