using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GeneratorScript))]
public class GeneratorEditor : Editor {

    public GameObject tree;

    public override void OnInspectorGUI() {
        GeneratorScript mapGen = (GeneratorScript)target;

        if (GUILayout.Button("Generate Tree(s)")) {
            mapGen.GenerateLine(tree);
        }
    }
}