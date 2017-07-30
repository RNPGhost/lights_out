using System.Collections.Generic;
using UnityEngine;

public class MonstersController : MonoBehaviour {
  // state
  private HashSet<MonsterController> _movingMonsters = new HashSet<MonsterController>();

  // references
  private GameController _gameController;
  private MonsterController[] _monsterControllers;

  // interface
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

  // initialisation
  private void Awake() {
    _gameController = FindObjectOfType<GameController>();
    _monsterControllers = FindObjectsOfType<MonsterController>();
  }
}
