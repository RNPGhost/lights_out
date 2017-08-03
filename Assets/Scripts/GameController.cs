using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
  // set in editor
  public GameObject _levelUI;
  public GameObject _gameOverUI;
  public Text _gameOverText;
  public string _winText;
  public string _lossText;

  // references
  private Map _map;

  // state
  private GameState _state;
  private CharacterController[] _characterControllers;
  private HashSet<CharacterController> _movingCharacters = new HashSet<CharacterController>();
  private Vector2 _playerTargetPosition;
  private PlayerController _playerController;

  // interface
  public Map GetMap() {
    return _map;
  }

  public void ReceiveInput(Vector2 direction) {
    MoveCharacters(_playerController.GetPosition() + direction);
  }

  public void MoveCharacters(Vector2 playerTargetPosition) {
    if (_state == GameState.WaitingForMove && _playerController.CanMoveTo(playerTargetPosition)) {
      _state = GameState.Moving;
      _playerTargetPosition = playerTargetPosition;
      if (_map.IsGoal(playerTargetPosition)) {
        _state = GameState.GameOver;
        // monsters don't move if the player will reach the goal this turn
        _movingCharacters.Add(_playerController);
        _playerController.Move(playerTargetPosition);
        SwitchToGameOverUI(won: true);
      } else {
        foreach (CharacterController characterController in _characterControllers) {
          _movingCharacters.Add(characterController);
        }
        foreach (CharacterController characterController in _characterControllers) {
          characterController.Move(playerTargetPosition);
        }
      }
    }
  }

  public void MovementComplete(CharacterController characterController) {
    if (characterController is MonsterController && characterController.GetPosition() == _playerTargetPosition) {
      PlayerCaught((MonsterController) characterController);
    }
    
    _movingCharacters.Remove(characterController);
    if (_movingCharacters.Count == 0 && _state == GameState.Moving) {
      _state = GameState.WaitingForMove;
    }
  }

  // initialisation
  private void Awake() {
    _state = GameState.WaitingForMove;
    _map = new Map();
    new ObjectLoader(_map);
    _characterControllers = FindObjectsOfType<CharacterController>();
    _playerController = FindObjectOfType<PlayerController>();
  }

  // implementation
  private void PlayerCaught(MonsterController monsterController) {
    if (_state != GameState.GameOver) {
      _state = GameState.GameOver;
      SwitchToGameOverUI(won: false);
    }
  }

  private void SwitchToGameOverUI(bool won) {
    _gameOverText.text = won ? _winText : _lossText;
    _levelUI.SetActive(false);
    _gameOverUI.SetActive(true);
  }

  private enum GameState {
    WaitingForMove,
    Moving,
    GameOver
  }
}
