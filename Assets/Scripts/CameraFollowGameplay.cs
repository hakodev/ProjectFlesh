using UnityEngine;

public class CameraFollowGameplay : MonoBehaviour {
    private const float bedroomDeadzonePositionLeft = -3.412f;
    private const float bedroomDeadzonePositionRight = 3.412f;

    [SerializeField] private Transform playerTransform;

    private void LateUpdate() {
        FollowPlayerWithinBounds();
    }

    private void FollowPlayerWithinBounds() {
        float clampedPosition = Mathf.Clamp(playerTransform.position.x, bedroomDeadzonePositionLeft, bedroomDeadzonePositionRight);

        this.transform.position = new Vector3(clampedPosition, this.transform.position.y, this.transform.position.z);
    }
}
