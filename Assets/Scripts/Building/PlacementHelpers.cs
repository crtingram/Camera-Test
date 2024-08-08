using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacementHelpers {

    public static bool RaycastFromMouse(out RaycastHit h, LayerMask layer) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out h, Mathf.Infinity, layer)) {
            return true;
        }
        return false;
    }

    public static bool IsButtonPressed(GraphicRaycaster raycaster) {
        // TODO Understand me.
        if (!EventSystem.current) {
            Debug.LogError("EventSystem not found");
            return true;
        }
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        List<RaycastResult> results = new List<RaycastResult>();
        eventData.position = Input.mousePosition;
        raycaster.Raycast(eventData, results);
        return results.Count != 0;
    }

}
