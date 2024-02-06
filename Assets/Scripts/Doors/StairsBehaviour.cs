using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StairsBehaviour : MonoBehaviour {
    [SerializeField] private RoomTeleporter teleporter;
    [SerializeField] private CameraFollowGameplay cameraFollower;
    [SerializeField] private TextMeshProUGUI stairsInteractionText;
    [SerializeField] private Image blackScreen;
    [SerializeField] private Transform basementDoorTriggerTransform;
    [SerializeField] private Room basement;

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player")) {
            stairsInteractionText.DOFade(1f, 0.25f);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player")) {
            stairsInteractionText.DOFade(0f, 0.25f);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player") && Input.GetKey(KeyCode.E)) {
            blackScreen.DOFade(1f, 0.5f).OnComplete(() => TeleportToLivingRoom());
        }
    }

    private void TeleportToLivingRoom() {
        Vector3 newCameraYPosition = cameraFollower.transform.position;
        Vector3 newPlayerPosition = teleporter.gameObject.transform.position;
        newPlayerPosition.x = basementDoorTriggerTransform.position.x;
        newPlayerPosition.y = teleporter.LivingRoomBasementDoorSpawnY;
        teleporter.gameObject.transform.position = newPlayerPosition;
        basement.LeaveRoom();
        newCameraYPosition.y = cameraFollower.LivingRoomPositionY;
        cameraFollower.transform.position = newCameraYPosition;
        blackScreen.DOFade(0f, 0.5f);
    }
}
