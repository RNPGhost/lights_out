using UnityEngine;

public class GameObjectMover {
  //constants
  public const float WORLD_SCALE = 2;

  // references
  private CharacterController _characterController;
  private GameObject _gameObject;
  private Vector2 _mapSize;

  // interface
  public GameObjectMover(CharacterController characterController, GameObject gameObject, Vector2 mapSize) {
    _characterController = characterController;
    _gameObject = gameObject;
    _mapSize = mapSize;
  }

  public void MoveTo(Vector2 position) {
    _gameObject.transform.position = ConvertToWorldPosition(position);
    _characterController.MovementComplete();
  }

  public void MoveToStartPosition(Vector2 startPosition) {
    _gameObject.transform.position = ConvertToWorldPosition(startPosition);
  }

  // implementation
  private Vector3 ConvertToWorldPosition(Vector2 mapPosition) {
    float x = (mapPosition.x - (_mapSize.x - 1) / 2) * WORLD_SCALE;
    float y = 0;
    float z = (mapPosition.y - (_mapSize.y - 1) / 2) * WORLD_SCALE;
    return new Vector3(x, y, z);
  }
}
