using UnityEngine;

public class PlayerController : CharacterController {
  protected override void CreatePath(Vector2 playerTargetPosition) {
    AddTargetToPath(playerTargetPosition);
  }
}