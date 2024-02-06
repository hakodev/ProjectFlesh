using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RoomTeleporter : MonoBehaviour {
    [Header("Triggers")]
    [SerializeField] private BoxCollider2D bedroomToKitchen;
    [SerializeField] private BoxCollider2D kitchenToBedroom;
    [SerializeField] private BoxCollider2D kitchenToLivingRoom;
    [SerializeField] private BoxCollider2D livingRoomToKitchen;

    [Header("")]
    [SerializeField] private Image blackScreen;

    [Header("Spawn points")]
    [SerializeField] private Vector2 bedroomSpawnPosition;
    [SerializeField] private Vector2 kitchenSpawnPositionLeft;

    private void Start() {
        blackScreen.DOFade(0f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider == bedroomToKitchen ||
           otherCollider == kitchenToBedroom ||
           otherCollider == kitchenToLivingRoom ||
           otherCollider == livingRoomToKitchen)
        {
            blackScreen.DOFade(1f, 0.5f).OnComplete(() => {
                TeleportToRoom(otherCollider);
            });
            
            blackScreen.DOFade(0f, 0.5f);
        }
    }

    private void TeleportToRoom(Collider2D otherCollider) {
        if(otherCollider == bedroomToKitchen) {
            this.transform.position = kitchenSpawnPositionLeft;
        } else if(otherCollider == kitchenToBedroom) {
            this.transform.position = bedroomSpawnPosition;
        } else if(otherCollider == kitchenToLivingRoom) {

        } else if(otherCollider == livingRoomToKitchen) {

        }
    }
}
