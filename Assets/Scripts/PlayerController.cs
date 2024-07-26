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
        Item_Axe = transform.GetChild(1).gameObject;
        Item_Pickaxe = transform.GetChild(2).gameObject;
        Item_Sword = transform.GetChild(3).gameObject;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate() {
        PlayerMovement();
    }

    void Update() {
        UpdateItem();
        UpdateCamera();
    }

    void PlayerMovement() {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * walkSpeed);
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
