using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController {
  // references
  
  // interface
  public void AttemptToMove(Vector2 direction) {
    Vector2 target = GetPosition() + direction;
    if (CanMoveTo(target)) {
      GetGameController().MovePlayer(this, target);
    }
  }

  public override void MovementComplete() {
    GetGameController().PlayerMovementComplete();
  }

  // initialisation
  private void Start() {
    SetStartingPosition(GetMap().GetEntrancePosition());
  }
}
