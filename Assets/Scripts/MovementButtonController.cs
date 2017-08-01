using UnityEngine;

public class MovementButtonController : MonoBehaviour {
  // set in editor
  public Vector2 _direction;
  
  // references
  private GameController _gameController;

  // interface
  public void Clicked() {
    _gameController.ReceiveInput(_direction);
  }

  // initialisation
  public void Awake() {
    _gameController = FindObjectOfType<GameController>();
  }
}
