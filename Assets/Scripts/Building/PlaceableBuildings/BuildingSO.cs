using UnityEngine;


[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObject/Building", order = 1)]
public class BuildingSO : ScriptableObject {
    public string objectName = "Building Name";
    public GameObject buildingPrefab;
    public float buildTime;

    [Header("Building Cost")]
    [SerializeField] public int treeCost = 0;
    public int getTreeCost { get => treeCost; }

    public int rockCost = 0;
    public int getRockCost { get => rockCost; }

    public int goldCost = 0;
    public int getGoldCost { get => goldCost; }
}
