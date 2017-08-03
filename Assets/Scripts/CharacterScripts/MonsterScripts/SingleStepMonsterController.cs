﻿using UnityEngine;

public class SingleStepMonsterController : MonsterController {
  // set in editor
  public Vector2 _startDirection;
  public ChangeDirectionMode _changeDirectionMode;
  public int _numberOfDirectionUpdatesTried;

  // state
  private Vector2 _direction;

  // intialisation
  protected override void Awake() {
    base.Awake();
    _direction = Utils.GetDirectionRelativeToGameObjectForwards(_startDirection, gameObject);
  }

  // implementation
  protected override void CreatePath(Vector2 playerTargetPosition) {
    UpdateDirection();
    AddTargetToPath(GetTarget());
  }

  private Vector2 GetTarget() {
    return GetPosition() + _direction;
  }

  private void UpdateDirection() {
    for (int i = 0; i < _numberOfDirectionUpdatesTried; i++) {
      if (CanMoveTo(GetTarget())) {
        break;
      } else {
        ChangeDirection();
      }
    }
  }

  private void ChangeDirection() {
    switch (_changeDirectionMode) {
      case ChangeDirectionMode.TurnAround:
        _direction = -_direction;
        break;
      case ChangeDirectionMode.TurnLeft:
        _direction = new Vector2(-_direction.y, _direction.x);
        break;
      case ChangeDirectionMode.TurnRight:
        _direction = new Vector2(_direction.y, -_direction.x);
        break;
      default:
        break;
    }
  }
}

public enum ChangeDirectionMode {
  TurnLeft,
  TurnRight,
  TurnAround
}
