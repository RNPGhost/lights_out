using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CharacterController {
  // set in editor
  public Vector2 _startingPosition;

  // references
  private MonstersController _monstersController;

  // interface
  public virtual void MakeMove(Vector2 playerPosition) {
    TryMove(GetPosition() + new Vector2(0, -1));    
  }

  public bool TryMove(Vector2 target) {
    if (CanMoveTo(target)) {
      MoveCharacter(target);
      return true;
    } else {
      MovementComplete();
      return false;
    }
  }

  // implementation
  public override void MovementComplete() {
    _monstersController.MovementComplete(this);
  }

  // initialisation
  protected override void Awake() {
    base.Awake();
    _monstersController = FindObjectOfType<MonstersController>();
    SetStartingPosition(_startingPosition);
  }
}
