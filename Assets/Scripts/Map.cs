using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
  // set in editor
  public Vector2 _entrancePosition;
  public Vector2 _mapSize;

  // state
  private Dictionary<Vector2, TileType> _map = new Dictionary<Vector2, TileType>();

  // interface
  public Vector2 GetEntrancePosition() {
    return _entrancePosition;
  }

  public bool CanMoveTo(Vector2 position) {
    TileType tileType;
    return (_map.TryGetValue(position, out tileType)) && (tileType != TileType.Obstacle);
  }

  public Vector2 GetMapSize() {
    return _mapSize;
  }

  // initialisation
  private void Awake() {
    InitialiseMap();
  }
  
  // implementation
  private void InitialiseMap() {
    for (int x = 0; x < _mapSize.x; x++) {
      for (int y = 0; y < _mapSize.y; y++) {
        _map.Add(new Vector2(x, y), TileType.Empty);
      }
    }
    
    _map[_entrancePosition] = TileType.Entrance;
  }
}

public enum TileType {
  Empty,
  Entrance,
  Goal,
  Obstacle
}