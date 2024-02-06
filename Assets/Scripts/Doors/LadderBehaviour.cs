using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LadderBehaviour : MonoBehaviour {
    [SerializeField] private RoomTeleporter teleporter;
    [SerializeField] private CameraFollowGameplay cameraFollower;
    [SerializeField] private TextMeshProUGUI ladderInteractionText;
    [SerializeField] private Image blackScreen;
    [SerializeField] private Transform trapDoorTriggerTransform;
    [SerializeField] private Room basement;

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player")) {
            ladderInteractionText.DOFade(1f, 0.25f);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player")) {
            ladderInteractionText.DOFade(0f, 0.25f);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player") && Input.GetKey(KeyCode.E)) {
            blackScreen.DOFade(1f, 0.5f).OnComplete(() => TeleportToKitchen());
        }
    }

    private void TeleportToKitchen() {
        Vector3 newCameraYPosition = cameraFollower.transform.position;
        Vector3 newPlayerPosition = teleporter.gameObject.transform.position;
        newPlayerPosition.x = trapDoorTriggerTransform.position.x;
        newPlayerPosition.y = teleporter.KitchenTrapDoorSpawnY;
        teleporter.gameObject.transform.position = newPlayerPosition;
        basement.LeaveRoom();
        newCameraYPosition.y = cameraFollower.KitchenPositionY;
        cameraFollower.transform.position = newCameraYPosition;
        blackScreen.DOFade(0f, 0.5f);
    }
}
