using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using OpenCover.Framework.Model;

public class SpawnBuildings : MonoBehaviour {

    #region 
    [TooltipAttribute("The tile GameObject that make up the grid")]
    [SerializeField] GameObject productionTile;

    [TooltipAttribute("The layer in which the terrain is placed")]
    [SerializeField] LayerMask terrainLayer;

    [TooltipAttribute("Need GraphicRaycaster to detect click on a button")]
    [SerializeField] GraphicRaycaster uiRaycaster;

    [SerializeField] BuildProgressSO buildingToPlace;
    #endregion

    #region Instance Objects
    GameObject currentSpawnedBuilding;
    List<ProductionTile> activeTiles;
    RaycastHit hit;
    #endregion


    void Start() {
        activeTiles = new List<ProductionTile>();
        if (!productionTile) {
            Debug.LogError("Production Tile is NULL");
        }
        if (!uiRaycaster) {
            Debug.Log("GraphicRaycaster not found! Will place objects on button click");
        }
    }

    void FixedUpdate() {
        if (currentSpawnedBuilding) {
            if (PlacementHelpers.RaycastFromMouse(out hit, terrainLayer)) {
                currentSpawnedBuilding.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
    }

    void Update() {
        if (currentSpawnedBuilding) {
            // TODO Use events instead of.
            if (Input.GetMouseButton(0)) {
                if (!PlacementHelpers.RaycastFromMouse(out hit, terrainLayer)) {
                    return;
                }

                currentSpawnedBuilding.transform.position = hit.point;

                if (CanPlaceBuilding()) {
                    GameObject instance = currentSpawnedBuilding;
                    currentSpawnedBuilding = null;
                    PlacementHelpers.ToggleRenderers(instance, true);
                }
            }

            if (Input.GetMouseButtonDown(1)) {
                Destroy(currentSpawnedBuilding);
            }

        }
    }

    bool CanPlaceBuilding() {
        if (PlacementHelpers.IsButtonPressed(uiRaycaster)) {
            return false;
        }
        // We add collision testing here.
        return true;
    }

    public void SpawnBuilding(BuildingSO building) {
        if (currentSpawnedBuilding) {
            return;
        }
        currentSpawnedBuilding = Instantiate(building.buildingPrefab);
        // currentSpawnedBuilding.GetComponent<Material>().color
    }

}
