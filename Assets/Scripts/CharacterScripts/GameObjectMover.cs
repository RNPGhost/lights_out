using UnityEngine;

public class GameObjectMover {
  //constants
  public const float WORLD_SCALE = 2;

  // references
  private CharacterController _characterController;
  private GameObject _gameObject;

  // state
  private bool _moveTowardsTarget = false;
  private Vector3 _target;
  public float _speed;

  // interface
  public GameObjectMover(CharacterController characterController, GameObject gameObject) {
    _characterController = characterController;
    _gameObject = gameObject;
  }

  public void MoveTo(Vector2 position, float speed) {
    _speed = speed * WORLD_SCALE;
    _target = Utils.ConvertToWorldPosition(position);
    _moveTowardsTarget = true;
  }

  public void MoveToStartPosition(Vector2 startPosition) {
    _gameObject.transform.position = Utils.ConvertToWorldPosition(startPosition);
  }

  public void Update() {
    if (_moveTowardsTarget) {
      float step = _speed * Time.deltaTime;
      _gameObject.transform.position = Vector3.MoveTowards(_gameObject.transform.position, _target, step);
      if (_gameObject.transform.position == _target) {
        _moveTowardsTarget = false;
        _characterController.StepComplete();
      }
    }
  }
}
