using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnBuildings : MonoBehaviour {

    public float rotationSpeed = 300f;

    #region 
    [TooltipAttribute("The layer in which the terrain is placed")]
    [SerializeField] LayerMask terrainLayer;

    [TooltipAttribute("Need GraphicRaycaster to detect click on a button")]
    [SerializeField] GraphicRaycaster uiRaycaster;

    [SerializeField] BuildProgressSO buildingToPlace;
    #endregion

    #region Instance Objects
    GameObject currentSpawnedBuilding;
    BuildingSO buildingSo;
    RaycastHit hit;
    #endregion

    [System.Serializable]
    public class UpdateResourcePanel : UnityEvent<PlayerController.ResourceContainer> {
    }
    public UpdateResourcePanel updateResourcePanel;

    void Start() {
        if (!uiRaycaster) {
            Debug.Log("GraphicRaycaster not found! Will place objects on button click");
        }
    }

    void FixedUpdate() {
        if (currentSpawnedBuilding) {
            // We need to be on terrainLayer in order to built.
            if (PlacementHelpers.RaycastFromMouse(out hit, terrainLayer)) {
                currentSpawnedBuilding.transform.position = new Vector3(hit.point.x, currentSpawnedBuilding.transform.position.y, hit.point.z);
            }
        }
    }

    void Update() {
        if (currentSpawnedBuilding) {
            if (Input.GetKey(KeyCode.Q)) {
                currentSpawnedBuilding.gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.E)) {
                currentSpawnedBuilding.gameObject.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
            }

            // TODO Use events instead of.
            if (Input.GetMouseButton(0)) {
                if (!PlacementHelpers.RaycastFromMouse(out hit, terrainLayer)) {
                    return;
                }

                currentSpawnedBuilding.transform.position = new Vector3(hit.point.x, currentSpawnedBuilding.transform.position.y, hit.point.z);

                if (CanPlaceBuilding()) {
                    if (CheckBuildingCost()) {
                        return;
                    }
                    else {
                        UpdatePlayerResourcePanel();
                    }

                    GameObject instance = currentSpawnedBuilding;
                    Destroy(currentSpawnedBuilding.GetComponent<BuildCollisionChecks>());
                    currentSpawnedBuilding = null;
                }
            }

            if (Input.GetMouseButtonDown(1)) {
                Destroy(currentSpawnedBuilding);
                buildingSo = null;
            }

        }
    }

    bool CanPlaceBuilding() {
        if (PlacementHelpers.IsButtonPressed(uiRaycaster)) {
            return false;
        }
        return !currentSpawnedBuilding.GetComponent<BuildCollisionChecks>().colliding;
    }

    bool CheckBuildingCost() {
        return !(PlayerController.resCont.tree >= buildingSo.treeCost) ||
                 !(PlayerController.resCont.rock >= buildingSo.rockCost) ||
                    !(PlayerController.resCont.gold >= buildingSo.goldCost);
    }

    void UpdatePlayerResourcePanel() {
        PlayerController.resCont.tree -= buildingSo.treeCost;
        PlayerController.resCont.rock -= buildingSo.rockCost;
        PlayerController.resCont.gold -= buildingSo.goldCost;
        updateResourcePanel.Invoke(PlayerController.resCont);
    }

    public void SpawnBuilding(BuildingSO building) {
        if (currentSpawnedBuilding) {
            return;
        }
        buildingSo = building;
        currentSpawnedBuilding = Instantiate(building.buildingPrefab);
    }

}
