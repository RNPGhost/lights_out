using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButtonController : MonoBehaviour {
  // set in editor
  public Vector2 _direction;
  
  // references
  private PlayerController _playerController;

  // interface
  public void Clicked() {
    _playerController.AttemptToMove(_direction);
  }

  public void SetPlayerController(PlayerController playerController) {
    _playerController = playerController;
  }
}
