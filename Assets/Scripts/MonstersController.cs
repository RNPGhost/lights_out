using System.Collections.Generic;
using UnityEngine;

public class MonstersController {
  // state
  private HashSet<MonsterController> _movingMonsters = new HashSet<MonsterController>();

  // references
  private GameController _gameController;
  private MonsterController[] _monsterControllers;

  // interface
  public MonstersController(GameController gameController, MonsterController[] monsterControllers) {
    _gameController = gameController;
    _monsterControllers = monsterControllers;
  }

  public void MoveMonsters(Vector2 playerPosition) {
    if (_monsterControllers.Length == 0) {
      _gameController.MonstersMovementComplete();
    } else {
      foreach (MonsterController monsterController in _monsterControllers) {
        monsterController.MakeMove(playerPosition);
        _movingMonsters.Add(monsterController);
      }
    }
  }

  public void MovementComplete(MonsterController monsterController) {
    _movingMonsters.Remove(monsterController);
    if (_movingMonsters.Count == 0) {
      _gameController.MonstersMovementComplete();
    }
  }

  public void PlayerCaught(MonsterController monsterController) {
    _gameController.PlayerCaught(monsterController);
  }
}
