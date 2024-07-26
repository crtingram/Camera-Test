using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;

    public float zPosition = -300f;
    public float yPosition = 300f;

    void Update() {
        transform.position = player.transform.position + new Vector3(0, yPosition, zPosition);
    }
}
