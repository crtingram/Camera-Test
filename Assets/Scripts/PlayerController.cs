using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    private CharacterController controller;
    private GameObject itemAxe, itemPickaxe, itemSword;

    public float walkSpeed = 400.0f;
    public float gatherRange = 100.0f;

    private Transform target;
    private RaycastHit raycastHit;

    public ResourceContainer resCont;

    [System.Serializable]
    public class OnResourceGather : UnityEvent<int> {
    }
    public OnResourceGather OnTreeGather, OnRockGather, OnGoldGather;

    [System.Serializable]
    public class OnObjectSelect : UnityEvent<String> {
    }
    public OnObjectSelect objectSelect;

    void Start() {
        itemAxe = transform.GetChild(0).gameObject;
        itemPickaxe = transform.GetChild(1).gameObject;
        itemSword = transform.GetChild(2).gameObject;
        controller = gameObject.GetComponent<CharacterController>();
        resCont = new ResourceContainer();
    }

    void FixedUpdate() {
        PlayerMovement();
    }

    void Update() {
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
                    float dist = Vector3.Distance(res.gameObject.transform.position, transform.position);
                    if (dist >= gatherRange) {
                        // TODO Works but we need to fix the distance.
                        return;
                    }
                    res.TakeDamage(1);
                    // This is not good code and I dont care.
                    // Generification -- How? Interfaces, Inheritance.
                    if (res.type == Resource.ResourceType.tree) {
                        resCont.incrementTree(1);
                        OnTreeGather.Invoke(resCont.tree);
                    }
                    else if (res.type == Resource.ResourceType.rock) {
                        resCont.incrementRock(1);
                        OnRockGather.Invoke(resCont.rock);
                    }
                    else if (res.type == Resource.ResourceType.gold) {
                        resCont.incrementGold(1);
                        OnGoldGather.Invoke(resCont.gold);
                    }
                }
                else {
                    target = null;
                }
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

    public void SwitchToPickAxe() {
        itemAxe.SetActive(!itemAxe.activeSelf);
        itemPickaxe.SetActive(false);
        itemSword.SetActive(false);
    }

    public void SwitchToAxe() {
        itemAxe.SetActive(false);
        itemPickaxe.SetActive(!itemPickaxe.activeSelf);
        itemSword.SetActive(false);
    }

    public void SwitchToSword() {
        itemAxe.SetActive(false);
        itemPickaxe.SetActive(false);
        itemSword.SetActive(!itemSword.activeSelf);
    }

    public class ResourceContainer {

        private int _tree = 0;
        private int _rock = 0;
        private int _gold = 0;

        public int tree {
            get => _tree;
            set {
                _tree = value;
            }
        }

        public int rock {
            get => _rock;
            set {
                _rock = value;
            }
        }

        public int gold {
            get => _gold;
            set {
                _gold = value;
            }
        }

        public void incrementTree(int incr) {
            _tree += incr;
        }

        public void incrementRock(int incr) {
            _rock += incr;
        }

        public void incrementGold(int incr) {
            _gold += incr;
        }

        public override string ToString() {
            return "Tree: " + tree + "; Rock: " + rock + "; Gold: " + gold + ";";
        }

    }

}
