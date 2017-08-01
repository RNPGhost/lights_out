using UnityEngine;

public class PlayerController : CharacterController {
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
  protected override void Awake() {
    base.Awake();
    foreach (MovementButtonController movementButtonController in FindObjectsOfType<MovementButtonController>()) {
      movementButtonController.SetPlayerController(this);
    }
  }
}