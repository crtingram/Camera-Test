using System;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour {

    public GameObject treeText, rockText, goldText, infoPanelText;

    void Start() {
        treeText.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        rockText.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        goldText.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        infoPanelText.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void UpdateTreeText(int i) {
        TextMeshProUGUI res = treeText.GetComponent<TextMeshProUGUI>();
        if (res) {
            res.text = i.ToString();
        }
    }

    public void UpdateRockText(int i) {
        TextMeshProUGUI res = rockText.GetComponent<TextMeshProUGUI>();
        if (res) {
            res.text = i.ToString();
        }
    }

    public void UpdateGoldText(int i) {
        TextMeshProUGUI res = goldText.GetComponent<TextMeshProUGUI>();
        if (res) {
            res.text = i.ToString();
        }
    }

    public void UpdateInformationPanel(String str) {
        TextMeshProUGUI res = infoPanelText.GetComponent<TextMeshProUGUI>();
        if (res) {
            res.text = str;
        }
    }

}
