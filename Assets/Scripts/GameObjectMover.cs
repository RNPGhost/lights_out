using UnityEngine;

public class GameObjectMover {
  //constants
  public const float WORLD_SCALE = 2;

  // state
  private GameObject _gameObject;
  private Vector2 _mapSize;

  // interface
  public GameObjectMover(GameObject gameObject) {
    _gameObject = gameObject;
  }

  public void MoveTo(Vector2 position) {
    _gameObject.transform.position = ConvertToWorldPosition(position);
  }

  public void MoveToStartPosition(Vector2 startPosition) {
    _gameObject.transform.position = ConvertToWorldPosition(startPosition);
  }

  // implementation
  private Vector3 ConvertToWorldPosition(Vector2 mapPosition) {
    float x = (mapPosition.x - _mapSize.x/2) * WORLD_SCALE;
    float y = 0;
    float z = (mapPosition.y - _mapSize.y / 2) * WORLD_SCALE;
    return new Vector3(x, y, z);
  }

  // initialisation
  private void Awake() {
    _mapSize = Object.FindObjectOfType<Map>().GetMapSize();
  }
}
