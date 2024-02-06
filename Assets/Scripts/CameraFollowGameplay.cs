using UnityEngine;

public class CameraFollowGameplay : MonoBehaviour {
    // Camera starts at x: -3.412 and y: 0

    private const float bedroomDeadzonePositionLeft = -3.412f;
    private const float bedroomDeadzonePositionRight = 3.412f;
    private const float bedroomPositionY = 0f;
    private const float kitchenDeadzonePositionLeft = -5.31f;
    private const float kitchenDeadzonePositionRight = 5.31f;
    private const float kitchenPositionY = -20f;
    private const float livingRoomDeadzonePositionLeft = -10.67f;
    private const float livingRoomDeadzonePositionRight = 10.67f;
    private const float livingRoomPositionY = -40f;
    private const float basementDeadzonePositionLeft = -12.697f;
    private const float basementDeadzonePositionRight = 12.697f;
    private const float basementPositionY = -60f;

    public float BedroomPositionY {
        get { return bedroomPositionY; }
    }

    public float KitchenPositionY {
        get { return kitchenPositionY; }
    }

    public float LivingRoomPositionY {
        get { return livingRoomPositionY; }
    }

    [SerializeField] private Transform playerTransform;

    private void LateUpdate() {
        FollowPlayerWithinBounds();
    }

    private void FollowPlayerWithinBounds() {
        float clampedX = 0f; // placeholder so it compiles
        if(this.transform.position.y == bedroomPositionY) {
            clampedX = Mathf.Clamp(playerTransform.position.x, bedroomDeadzonePositionLeft, bedroomDeadzonePositionRight);
        } else if(this.transform.position.y == kitchenPositionY) {
            clampedX = Mathf.Clamp(playerTransform.position.x, kitchenDeadzonePositionLeft, kitchenDeadzonePositionRight);
        } else if(this.transform.position.y == livingRoomPositionY) {
            clampedX = Mathf.Clamp(playerTransform.position.x, livingRoomDeadzonePositionLeft, livingRoomDeadzonePositionRight);
        } else if(this.transform.position.y == basementPositionY) {
            clampedX = Mathf.Clamp(playerTransform.position.x, basementDeadzonePositionLeft, basementDeadzonePositionRight);
        }

        this.transform.position = new Vector3(clampedX, this.transform.position.y, this.transform.position.z);
    }
}
