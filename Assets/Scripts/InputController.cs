using UnityEngine;

public class InputController : MonoBehaviour {
  // references
  public PlayerController _playerController;

  // implementation
  private void Update() {
    float xInput = Input.GetAxisRaw("Horizontal");
    float yInput = Input.GetAxisRaw("Vertical");
    if (xInput != 0) {
      _playerController.AttemptToMove(new Vector2(xInput, 0));
    } else if (yInput != 0) {
      _playerController.AttemptToMove(new Vector2(0, yInput));
    }
  }
}
