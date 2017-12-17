using UnityEngine;
using UnityEngine.UI;

public class SpeedChangeButtonController : MonoBehaviour {
  // set in editor
  public string _textPrefix;
  public Text _buttonText;

  // initialisation
  public void Start() {
    UpdateText();
  }

  // interface
  public void ChangeSpeed() {
    SpeedController.ChangeSpeed();
    UpdateText();
  }

  // implementation
  private void UpdateText() {
    _buttonText.text = _textPrefix + SpeedController.GetMovementSpeedText();
  }
}
