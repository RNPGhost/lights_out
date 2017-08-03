using UnityEngine;

public class PlayerController : CharacterController {
  // implementation
  protected override void CreatePath(Vector2 playerTargetPosition) {
    AddTargetToPath(playerTargetPosition);
  }
}