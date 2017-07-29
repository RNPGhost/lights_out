using UnityEngine;

public class GameController : MonoBehaviour {
  // references
  private MonstersController _monstersController;

  // state
  private GameState _state;

  // interface
  public void MovePlayer(PlayerController playerController, Vector2 playerPosition) {
    if (_state == GameState.WaitingForMove) {
      _state = GameState.Moving;
      playerController.MoveCharacter(playerPosition);
      _monstersController.MoveMonsters(playerPosition);
      // if collision, game over
    }
  }

  public void MovementComplete() {
    _state = GameState.WaitingForMove;
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
