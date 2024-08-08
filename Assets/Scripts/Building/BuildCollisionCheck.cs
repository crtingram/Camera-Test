using UnityEngine;

public class BuildCollisionChecks : MonoBehaviour {

    [SerializeField] LayerMask collisionLayers;

    [SerializeField] Color noCollisionColor = Color.green;
    [SerializeField] Color collisionColor = Color.red;

    private Material oldMaterial, unBuiltMaterial;

    public bool colliding { get; private set; }

    void Start() {
        if (gameObject.GetComponentsInChildren<Renderer>().Length == 1) {
            oldMaterial = GetComponent<Renderer>().material;
        }
        else if (gameObject.GetComponentsInChildren<Renderer>().Length > 1) {
            foreach (Renderer renderer in gameObject.GetComponentsInChildren<Renderer>()) {
                // Wont work ("correctly") if multiple materials.
                oldMaterial = renderer.material;
            }
        }

        unBuiltMaterial = new Material(Shader.Find("Diffuse"));
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
        SetColor(collisionColor);
        colliding = true;
    }

    void OnTriggerExit(Collider other) {
        SetColor(noCollisionColor);
        colliding = false;
    }

}