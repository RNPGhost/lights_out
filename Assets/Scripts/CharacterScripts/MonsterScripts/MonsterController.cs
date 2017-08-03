using UnityEngine;

public class MonsterController : CharacterController {
  // set in editor
  public bool _visibleWhenMoving;
  public bool _visibleWhenStationary;
  public GameObject _monsterVFX;

  // initialisation
  protected override void Awake() {
    base.Awake();
    _monsterVFX.SetActive(_visibleWhenStationary);
  }

  // implementation
  protected override void CreatePath(Vector2 playerTargetPosition) {
    AddTargetToPath(GetPosition() + new Vector2(0, -1));
  }

  protected override void MovementStarted() {
    base.MovementStarted();
    _monsterVFX.SetActive(_visibleWhenMoving);
  }

  protected override void MovementComplete() {
    base.MovementComplete();
    _monsterVFX.SetActive(_visibleWhenStationary);
  }
}
