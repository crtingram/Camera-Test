using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour {

    public GameObject treeText, rockText, goldText;

    void Start() {
        treeText.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        rockText.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        goldText.GetComponent<TextMeshProUGUI>().text = 0.ToString();
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

}
