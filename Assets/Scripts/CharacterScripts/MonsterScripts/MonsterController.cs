using UnityEngine;

public class MonsterController : CharacterController {
  // set in editor
  public bool _visibleWhenMoving;
  public bool _visibleWhenStationary;
  public GameObject _monsterVFX;

  // state
  private GameController _gameController;

  // initialisation
  protected override void Start() {
    base.Start();
    _monsterVFX.SetActive(_visibleWhenStationary);
    _gameController = FindObjectOfType<GameController>();
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

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.tag == Utils.GetPlayerTag()) {
      _gameController.PlayerCaught(this);
    }
  }
}
