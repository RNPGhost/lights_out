using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
  // set in editor
  public float _relativeSpeed;

  // references
  private Map _map;
  private GameController _gameController;
  private GameObjectMover _characterObjectMover;

  // state
  private Vector2 _characterPosition;
  private Queue<Vector2> _path = new Queue<Vector2>();
  private float _pathLength = 0;
  private Vector2 _currentTarget;

  // interface
  public void Move(Vector2 playerTargetPosition) {
    MovementStarted();
    CreatePath(playerTargetPosition);
    StepAlongPath();
  }

  public Vector2 GetPosition() {
    return _characterPosition;
  }

  public void StepComplete() {
    StepAlongPath();
  }

  // child interface
  protected virtual void CreatePath(Vector2 playerTargetPosition) { }

  protected virtual void MovementStarted() { }

  protected virtual void MovementComplete() {
    _gameController.MovementComplete(this);
  }

  protected void AddTargetToPath(Vector2 target) {
    if (CanMoveTo(target)) {
      _path.Enqueue(target);
      _pathLength += Vector2.Distance(target, _currentTarget);
      _currentTarget = target;
    }
  }

  protected bool CanMoveTo(Vector2 position) {
    return _map.CanMoveTo(position);
  }

  // initialisation
  protected virtual void Awake() {
    _characterPosition = Utils.ConvertToMapPosition(gameObject.transform.position);
    ClearPath();
    _gameController = FindObjectOfType<GameController>();
    _map = _gameController.GetMap();
    _characterObjectMover = new GameObjectMover(this, gameObject);
  }

  // implementation
  private void StepAlongPath() {
    if (_path.Count > 0) {
      Vector2 target = _path.Dequeue();
      _characterObjectMover.MoveTo(target, _relativeSpeed * Utils.GetCharacterSpeed(_pathLength));
      _characterPosition = target;
    } else {
      ClearPath();
      MovementComplete();
    }
  }

  protected virtual void Update() {
    _characterObjectMover.Update();
  }

  private void ClearPath() {
    _pathLength = 0;
    _currentTarget = GetPosition();
  }
}
