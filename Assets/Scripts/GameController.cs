using System;
using UnityEngine;

public class GameController : MonoBehaviour {
  // references
  private MonstersController _monstersController;

  // state
  private GameState _state;
  private bool _playerMoving = false;
  private bool _monstersMoving = false;

  // interface
  public void MovePlayer(PlayerController playerController, Vector2 playerPosition) {
    if (_state == GameState.WaitingForMove) {
      _state = GameState.Moving;
      _playerMoving = true;
      _monstersMoving = true;
      playerController.MoveCharacter(playerPosition);
      _monstersController.MoveMonsters(playerPosition);
      // if collision, game over
    }
  }

  public void MovementComplete() {
    _state = GameState.WaitingForMove;
  }

  public void CheckMovementComplete() {
    if (!_playerMoving && !_monstersMoving) {
      MovementComplete();
    }
  }

  public void PlayerMovementComplete() {
    _playerMoving = false;
    CheckMovementComplete();
  }

  public void MonstersMovementComplete() {
    _monstersMoving = false;
    CheckMovementComplete();
  }

  // initialisation
  private void Awake() {
    _state = GameState.WaitingForMove;
    _monstersController = FindObjectOfType<MonstersController>();
  }


  // implementation
  private enum GameState {
    WaitingForMove,
    Moving
  }
}
