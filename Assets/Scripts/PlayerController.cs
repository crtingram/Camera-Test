using UnityEngine;

public class PlayerController : MonoBehaviour {

    private CharacterController controller;
    private GameObject Item_Axe, Item_Pickaxe, Item_Sword;

    public float walkSpeed = 400.0f;

    private Transform target;
    private RaycastHit raycastHit;

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
        PlayerAngle();
        FillTarget();
    }

    void FillTarget() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit)) {
                target = raycastHit.transform;
                Resource res = target.GetComponent<Resource>();
                if (res) {
                    res.TakeDamage(10);
                }
            }
            else {
                target = null;
            }
        }
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
