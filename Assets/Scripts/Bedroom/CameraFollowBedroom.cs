using UnityEngine;

public class CameraFollowBedroom : MonoBehaviour {
    private const float deadzonePositionLeft = -3.412f;
    private const float deadzonePositionRight = 3.412f;

    [SerializeField] private Transform playerTransform;

    private void LateUpdate() {
        FollowPlayerWithinRoom();
    }

    private void FollowPlayerWithinRoom() {
        float clampedPosition = Mathf.Clamp(playerTransform.position.x, deadzonePositionLeft, deadzonePositionRight);

        this.transform.position = new Vector3(clampedPosition, this.transform.position.y, this.transform.position.z);
    }
}
