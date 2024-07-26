using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 400.0f;
    private CharacterController controller;

    [Header("--- Camera Settings ---")]
    public float cameraZoomSensitivity = 20f;
    public float cameraMinFov = 15f;
    public float cameraMaxFov = 100f;

    private GameObject Item_Axe, Item_Pickaxe, Item_Sword;

    void Start() {
        Item_Axe = transform.GetChild(0).gameObject;
        Item_Pickaxe = transform.GetChild(1).gameObject;
        Item_Sword = transform.GetChild(2).gameObject;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate() {
        PlayerMovement();
    }

    void Update() {
        UpdateItem();
        UpdateCamera(); // Move to camera script.
        PlayerAngle();
    }

    void PlayerMovement() {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * walkSpeed);
    }

    // Player looks at cursor.
    void PlayerAngle() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 newPos = new Vector3();
        newPos.x = mousePos.x - objectPos.x;
        newPos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(270, 0, -angle));
    }

    void UpdateCamera() {
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * cameraZoomSensitivity;
        // Clamp is probably unoptimized.
        fov = Mathf.Clamp(fov, cameraMinFov, cameraMaxFov);
        Camera.main.fieldOfView = fov;
    }

    void UpdateItem() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Item_Axe.SetActive(!Item_Axe.activeSelf);
            Item_Pickaxe.SetActive(false);
            Item_Sword.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Item_Axe.SetActive(false);
            Item_Pickaxe.SetActive(!Item_Pickaxe.activeSelf);
            Item_Sword.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Item_Axe.SetActive(false);
            Item_Pickaxe.SetActive(false);
            Item_Sword.SetActive(!Item_Sword.activeSelf);
        }
    }

}
