using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 400.0f;

    private CharacterController controller;

    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate() {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * walkSpeed);
    }

}
