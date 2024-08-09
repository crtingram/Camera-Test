using UnityEngine;

public class GeneratorScript : MonoBehaviour {

    public int lengthX = 1;

    public void GenerateLine(GameObject go) {
        for (int i = 0; i < lengthX; i++) {
            Instantiate(go);
        }
    }

}
