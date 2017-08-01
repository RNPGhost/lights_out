using UnityEngine;

public class InputController : MonoBehaviour {
  // references
  public GameController _gameController;
  
  // initialisation
  public void Awake() {
    _gameController = FindObjectOfType<GameController>();
  }

  // implementation
  private void Update() {
    float xInput = Input.GetAxisRaw("Horizontal");
    float yInput = Input.GetAxisRaw("Vertical");
    if (xInput != 0) {
      _gameController.ReceiveInput(new Vector2(xInput, 0));
    } else if (yInput != 0) {
      _gameController.ReceiveInput(new Vector2(0, yInput));
    }
  }
}
