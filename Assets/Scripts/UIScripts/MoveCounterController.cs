using UnityEngine;
using UnityEngine.UI;

public class MoveCounterController : MonoBehaviour {
  // set in editor
  public Text text;

  // references
  private GameController _gameController;
  
  // initialisation
  public void Awake() {
    _gameController = FindObjectOfType<GameController>();
  }

  // implementation
  private void Update() {
    text.text = _gameController.GetMoveNumber().ToString();
  }
}
