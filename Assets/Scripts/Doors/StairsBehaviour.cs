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
        Vector3 newYPosition = cameraFollower.transform.position;
        teleporter.gameObject.transform.position = basementDoorTriggerTransform.position;
        newYPosition.y = cameraFollower.LivingRoomPositionY;
        cameraFollower.transform.position = newYPosition;
        blackScreen.DOFade(0f, 0.5f);
    }
}
