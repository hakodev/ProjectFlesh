using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class BasementDoorBehaviour : MonoBehaviour {
    [SerializeField] private RoomTeleporter teleporter;
    [SerializeField] private CameraFollowGameplay cameraFollower;
    [SerializeField] private TextMeshProUGUI basementDoorInteractionText;
    [SerializeField] private Image blackScreen;

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player")) {
            basementDoorInteractionText.DOFade(1f, 0.25f);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player")) {
            basementDoorInteractionText.DOFade(0f, 0.25f);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider) {
        if(otherCollider.CompareTag("Player") && Input.GetKey(KeyCode.E)) {
            blackScreen.DOFade(1f, 0.5f).OnComplete(() => TeleportToBasementStairs());
        }
    }

    private void TeleportToBasementStairs() {
        Vector3 newYPosition = cameraFollower.transform.position;
        teleporter.gameObject.transform.position = teleporter.BasementSpawnPositionStairs;
        newYPosition.y = cameraFollower.BasementPositionY;
        cameraFollower.transform.position = newYPosition;
        blackScreen.DOFade(0f, 0.5f);
    }
}
