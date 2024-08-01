using UnityEngine;

public class ToggleActionBar : MonoBehaviour {

    public GameObject actionPanel, buildBuild;

    public KeyCode keyCode;

    public enum BarState {
        Build,
        Action
    }

    public BarState barState = BarState.Action;

    void Start() {
        actionPanel.SetActive(barState == BarState.Action);
        buildBuild.SetActive(barState == BarState.Build);
    }

    void Update() {
        // TODO Again... use events for this.
        if (Input.GetKeyDown(keyCode)) {
            if (barState == BarState.Action) {
                barState = BarState.Build;
            }
            else {
                barState = BarState.Action;
            }
        }

        actionPanel.SetActive(barState == BarState.Action);
        buildBuild.SetActive(barState == BarState.Build);
    }
}
