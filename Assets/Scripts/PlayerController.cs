using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController {
  // references
  private Map _map;
  private GameController _gameController;
  
  // interface
  public void AttemptToMove(Vector2 direction) {
    Vector2 target = GetPosition() + direction;
    if (_map.CanMoveTo(target)) {
      _gameController.MovePlayer(this, target);
    }
  }

  public override void MovementComplete() {
    _gameController.PlayerMovementComplete();
  }

  // initialisation
  protected override void Awake() {
    base.Awake();
    _map = FindObjectOfType<Map>();
    _gameController = FindObjectOfType<GameController>();
  }

  private void Start() {
    SetStartingPosition(_map.GetEntrancePosition());
  }
}
