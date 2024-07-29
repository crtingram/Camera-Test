using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {

    public delegate void ClickAction(int i);
    public static event ClickAction incrementTree;

    public static void RaiseClickAction() {
        if (incrementTree != null) {
            incrementTree(1);
        }
    }

    public TextMesh treeText;

    public void UpdateTreeText() {
        Debug.Log("Test ASDF");
        treeText.text = "test";
    }

}
