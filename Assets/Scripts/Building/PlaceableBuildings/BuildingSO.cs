using UnityEngine;


[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObject/Building", order = 1)]
public class BuildingSO : ScriptableObject {
    public string objectName = "Building Name";
    public GameObject buildingPrefab;
    public float buildTime;
    public float cost;
}