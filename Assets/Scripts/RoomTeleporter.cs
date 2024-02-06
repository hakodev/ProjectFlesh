using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RoomTeleporter : MonoBehaviour {
    [SerializeField] private CameraFollowGameplay cameraFollower;

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
    [SerializeField] private Vector2 kitchenSpawnPositionRight;

    private void Start() {
        blackScreen.DOFade(0f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider == bedroomToKitchen ||
           otherCollider == kitchenToBedroom ||
           otherCollider == kitchenToLivingRoom ||
           otherCollider == livingRoomToKitchen)
        {
            blackScreen.DOFade(1f, 0.5f).OnComplete(() => TeleportToRoom(otherCollider));
        }
    }

    private void TeleportToRoom(Collider2D otherCollider) {
        Vector2 newYPosition = cameraFollower.transform.position;

        if(otherCollider == bedroomToKitchen) {
            this.transform.position = kitchenSpawnPositionLeft;
            newYPosition.y = cameraFollower.KitchenPositionY;
        } else if(otherCollider == kitchenToBedroom) {
            this.transform.position = bedroomSpawnPosition;
            newYPosition.y = cameraFollower.BedroomPositionY;
        } else if(otherCollider == kitchenToLivingRoom) {

        } else if(otherCollider == livingRoomToKitchen) {
            this.transform.position = kitchenSpawnPositionRight;
            newYPosition.y = cameraFollower.KitchenPositionY;
        }

        cameraFollower.transform.position = newYPosition;
        blackScreen.DOFade(0f, 0.5f);
    }
}
