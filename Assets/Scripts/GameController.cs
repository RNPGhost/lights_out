using UnityEngine;

public class GameController : MonoBehaviour {
  // references
  private MonstersController _monstersController;
  private Map _map;

  // state
  private GameState _state;
  private bool _playerMoving = false;
  private bool _monstersMoving = false;

  // interface
  public Map GetMap() {
    return _map;
  }

  public MonstersController GetMonstersController() {
    return _monstersController;
  }

  public void MovePlayer(PlayerController playerController, Vector2 playerPosition) {
    if (_state == GameState.WaitingForMove) {
      _state = GameState.Moving;
      _playerMoving = true;
      _monstersMoving = true;
      playerController.MoveCharacter(playerPosition);
      _monstersController.MoveMonsters(playerPosition);
      if (_map.IsGoal(playerPosition)) {
        _state = GameState.GameOver;
        // display win screen
      }
    }
  }

  public void MovementComplete() {
    if (_state == GameState.Moving) {
      _state = GameState.WaitingForMove;
    }
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

  public void PlayerCaught(MonsterController monsterController) {
    if (_state != GameState.GameOver) {
      _state = GameState.GameOver;
      // display player loses screen
    }
  }

  // initialisation
  private void Awake() {
    _state = GameState.WaitingForMove;
    _map = new Map();
    new ObjectLoader(_map);
    _monstersController = new MonstersController(this, FindObjectsOfType<MonsterController>());
  }


  // implementation
  private enum GameState {
    WaitingForMove,
    Moving,
    GameOver
  }
}
