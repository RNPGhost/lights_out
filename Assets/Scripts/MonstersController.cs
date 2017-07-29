using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersController : MonoBehaviour {
  // references
  private GameController _gameController;

  // interface
  public void MoveMonsters(Vector2 playerPosition) {
    _gameController.MonstersMovementComplete();
  }

  // initialisation
  private void Awake() {
    _gameController = FindObjectOfType<GameController>();
  }
}
