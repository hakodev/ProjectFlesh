using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TrapDoorBehaviour : MonoBehaviour {
    [SerializeField] private RoomTeleporter teleporter;
    [SerializeField] private CameraFollowGameplay cameraFollower;
    [SerializeField] private TextMeshProUGUI trapDoorInteractionText;
    [SerializeField] private Image blackScreen;
    [SerializeField] private Room kitchen;

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player")) {
            trapDoorInteractionText.DOFade(1f, 0.25f);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player")) {
            trapDoorInteractionText.DOFade(0f, 0.25f);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player") && Input.GetKey(KeyCode.E)) {
            blackScreen.DOFade(1f, 0.5f).OnComplete(() => TeleportToBasementLadder());
        }
    }

    private void TeleportToBasementLadder() {
        Vector3 newCameraYPosition = cameraFollower.transform.position;
        teleporter.gameObject.transform.position = teleporter.BasementSpawnPositionLadder;
        kitchen.LeaveRoom();
        newCameraYPosition.y = cameraFollower.BasementPositionY;
        cameraFollower.transform.position = newCameraYPosition;
        blackScreen.DOFade(0f, 0.5f);
    }
}
