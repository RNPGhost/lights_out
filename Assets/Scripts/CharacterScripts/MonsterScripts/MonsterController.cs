using UnityEngine;

public class MonsterController : CharacterController {
  // set in editor
  public bool _visibleWhenMoving;
  public bool _visibleWhenStationary;
  public GameObject _monsterVFX;

  // initialisation
  protected override void Start() {
    base.Start();
    _monsterVFX.SetActive(_visibleWhenStationary);
  }

  // implementation
  protected override void MovementStarted() {
    base.MovementStarted();
    _monsterVFX.SetActive(_visibleWhenMoving);
  }

  protected override void MovementComplete() {
    base.MovementComplete();
    _monsterVFX.SetActive(_visibleWhenStationary);
  }
}
