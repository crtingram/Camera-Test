using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;

    public float zPosition = -300f;
    public float yPosition = 300f;

    [Header("--- Camera Settings ---")]
    public float cameraZoomSensitivity = 20f;
    public float cameraMinFov = 15f;
    public float cameraMaxFov = 100f;

    void Update() {
        transform.position = player.transform.position + new Vector3(0, yPosition, zPosition);
        Zoom(); // Calling this once a frame may not be ideal...
    }

    void Zoom() {
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * cameraZoomSensitivity;
        // Clamp is probably unoptimized.
        fov = Mathf.Clamp(fov, cameraMinFov, cameraMaxFov);
        Camera.main.fieldOfView = fov;
    }
}
