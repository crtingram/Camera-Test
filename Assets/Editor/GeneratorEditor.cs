using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GeneratorScript))]
public class GeneratorEditor : Editor {

    public GameObject test;

    public override void OnInspectorGUI() {
        GeneratorScript mapGen = (GeneratorScript)target;

        if (GUILayout.Button("Generate")) {
            mapGen.GenerateLine();
        }
    }
}