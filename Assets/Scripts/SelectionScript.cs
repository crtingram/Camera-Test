using UnityEngine;

public class SelectionScript : MonoBehaviour {

    public Material highlightMaterial;
    public Material selectionMaterial;

    private Material originalMaterial;
    private Transform highlight;
    private Transform selectedTransform;
    private RaycastHit raycastHit;

    void Update() {
        // Highlight an object on mouse-over if it has a Selectable tag using Raycast
        if (highlight != null) {
            highlight.GetComponent<MeshRenderer>().material = originalMaterial;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit)) {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selectedTransform) {
                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial) {
                    originalMaterial = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
            }
            else {
                highlight = null;
            }
        }

        // Select an object on the mouse Click if it has a Selectable tag using Raycast 
        if (Input.GetKey(KeyCode.Mouse0)) {
            if (selectedTransform != null) {
                selectedTransform.GetComponent<MeshRenderer>().material = originalMaterial;
                selectedTransform = null;
            }
            if (Physics.Raycast(ray, out raycastHit)) {
                selectedTransform = raycastHit.transform;
                if (selectedTransform.CompareTag("Selectable")) {
                    selectedTransform.GetComponent<MeshRenderer>().material = selectionMaterial;
                }
                else {
                    selectedTransform = null;
                }
            }
            else {
                selectedTransform = null;
            }
        }
    }

}
