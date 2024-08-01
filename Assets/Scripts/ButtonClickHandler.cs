using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour {

    public KeyCode key;
    private Button _button;

    void Awake() {
        _button = GetComponent<Button>();
    }

    void Update() {
        // TODO Set this up for listener.
        if (Input.GetKeyDown(key)) {
            FadeToColor(_button.colors.pressedColor);
            _button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(key)) {
            FadeToColor(_button.colors.normalColor);
        }
    }

    void FadeToColor(Color color) {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    }

}
