using UnityEngine;

public class GameObjectMover {
  //constants
  public const float WORLD_SCALE = 2;
  public readonly float SPEED;

  // references
  private CharacterController _characterController;
  private GameObject _gameObject;
  private Vector2 _mapSize;

  // state
  private bool _moveTowardsTarget = false;
  private Vector3 _target;

  // interface
  public GameObjectMover(CharacterController characterController, GameObject gameObject, Vector2 mapSize, float speed) {
    _characterController = characterController;
    _gameObject = gameObject;
    _mapSize = mapSize;
    SPEED = speed;
  }

  public void MoveTo(Vector2 position) {
    _target = ConvertToWorldPosition(position);
    _moveTowardsTarget = true;
  }

  public void MoveToStartPosition(Vector2 startPosition) {
    _gameObject.transform.position = ConvertToWorldPosition(startPosition);
  }

  public void Update() {
    if (_moveTowardsTarget) {
      float step = SPEED * Time.deltaTime;
      _gameObject.transform.position = Vector3.MoveTowards(_gameObject.transform.position, _target, step);
      if (_gameObject.transform.position == _target) {
        _moveTowardsTarget = false;
        _characterController.MovementComplete();
      }
    }
  }

  // implementation
  private Vector3 ConvertToWorldPosition(Vector2 mapPosition) {
    float x = (mapPosition.x - (_mapSize.x - 1) / 2) * WORLD_SCALE;
    float y = 0;
    float z = (mapPosition.y - (_mapSize.y - 1) / 2) * WORLD_SCALE;
    return new Vector3(x, y, z);
  }
}
