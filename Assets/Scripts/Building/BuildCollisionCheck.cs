using UnityEngine;

public class BuildCollision : MonoBehaviour {

    [SerializeField] LayerMask collisionLayers;

    [SerializeField] Color noCollisionColor = Color.green;
    [SerializeField] Color collisionColor = Color.red;

    private Material oldMaterial, unBuiltMaterial;

    void Start() {
        unBuiltMaterial = new Material(Shader.Find("Diffuse")) {
            color = noCollisionColor
        };

        SetColor(noCollisionColor);
    }

    void SetColor(Color c) {
        unBuiltMaterial.color = c;

        if (gameObject.GetComponentsInChildren<Renderer>().Length == 1) {
            GetComponent<Renderer>().material = unBuiltMaterial;
        }
        else if (gameObject.GetComponentsInChildren<Renderer>().Length > 1) {
            foreach (Renderer renderer in gameObject.GetComponentsInChildren<Renderer>()) {
                renderer.material = unBuiltMaterial;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer))) {
            if (other.gameObject.transform.root.gameObject.GetInstanceID() != transform.root.gameObject.GetInstanceID()) {
                SetColor(collisionColor);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer))) {
            SetColor(noCollisionColor);
        }
    }

}
