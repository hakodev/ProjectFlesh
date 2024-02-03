using UnityEngine;

public class CameraFollowGameplay : MonoBehaviour {
    private const float deadzonePositionLeft = -8.65f;
    private const float deadzonePositionRight = 8.65f;
    private const float deadzonePositionUp = 3.48f;
    private const float deadzonePositionDown = -5.8f;

    [SerializeField] private Transform playerTransform;

    private void LateUpdate() {
        FollowPlayerWithinBounds();
    }

    private void FollowPlayerWithinBounds() {
        float clampedX = Mathf.Clamp(playerTransform.position.x, deadzonePositionLeft, deadzonePositionRight);
        float clampedY = Mathf.Clamp(playerTransform.position.y, deadzonePositionDown, deadzonePositionUp);

        this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
    }
}
