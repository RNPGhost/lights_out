using UnityEngine;

public class MonsterController : CharacterController {
  protected override void CreatePath(Vector2 playerTargetPosition) {
    AddTargetToPath(GetPosition() + new Vector2(0, -1));
  }
}
