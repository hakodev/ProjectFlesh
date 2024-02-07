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

    private const float longBedroomDeadzonePositionLeft = -20.872f;
    private const float longBedroomDeadzonePositionRight = 20.872f;
    private const float longBedroomPositionY = 20f;

    public float BedroomPositionY {
        get { return bedroomPositionY; }
    }

    public float KitchenPositionY {
        get { return kitchenPositionY; }
    }

    public float LivingRoomPositionY {
        get { return livingRoomPositionY; }
    }

    public float BasementPositionY {
        get { return basementPositionY; }
    }

    public float LongBedroomPositionY {
        get { return longBedroomPositionY; }
    }

    [SerializeField] private Transform playerTransform;

    private void LateUpdate() {
        FollowPlayerWithinBounds();
    }

    private void FollowPlayerWithinBounds() {
        float clampedX = 0f; // placeholder so it compiles
        switch(this.transform.position.y) {
            case bedroomPositionY:
                clampedX = Mathf.Clamp(playerTransform.position.x, bedroomDeadzonePositionLeft, bedroomDeadzonePositionRight);
                break;
            case kitchenPositionY:
                clampedX = Mathf.Clamp(playerTransform.position.x, kitchenDeadzonePositionLeft, kitchenDeadzonePositionRight);
                break;
            case livingRoomPositionY:
                clampedX = Mathf.Clamp(playerTransform.position.x, livingRoomDeadzonePositionLeft, livingRoomDeadzonePositionRight);
                break;
            case basementPositionY:
                clampedX = Mathf.Clamp(playerTransform.position.x, basementDeadzonePositionLeft, basementDeadzonePositionRight);
                break;
            case longBedroomPositionY:
                clampedX = Mathf.Clamp(playerTransform.position.x, longBedroomDeadzonePositionLeft, longBedroomDeadzonePositionRight);
                break;
        }
        this.transform.position = new Vector3(clampedX, this.transform.position.y, this.transform.position.z);
    }
}
