using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CharacterController {
  // set in editor
  public Vector2 _startingPosition;

  // references
  private MonstersController _monstersController;

  // state
  private bool _playerCaught = false;

  // interface
  public virtual void MakeMove(Vector2 playerPosition) {
    TryMove(GetPosition() + new Vector2(0, -1), playerPosition);    
  }

  public bool TryMove(Vector2 target, Vector2 playerPosition) {
    if (CanMoveTo(target)) {
      MoveCharacter(target);
      if (target == playerPosition) {
        PlayerCaught();
      }
      return true;
    } else {
      MovementComplete();
      return false;
    }
  }
  
  public override void MovementComplete() {
    _monstersController.MovementComplete(this);
  }

  // initialisation
  protected override void Awake() {
    base.Awake();
    _monstersController = FindObjectOfType<MonstersController>();
    SetStartingPosition(_startingPosition);
  }

  // implementation
  private void PlayerCaught() {
    _playerCaught = true;
    _monstersController.PlayerCaught(this);
  }

  protected bool IsPlayerCaught() {
    return _playerCaught;
  }
}
