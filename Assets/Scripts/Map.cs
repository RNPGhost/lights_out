﻿using System.Collections.Generic;
using UnityEngine;

public class Map {
  // state
  private Dictionary<Vector2, TileType> _map = new Dictionary<Vector2, TileType>();
  private Vector2 _topRightCorner;
  private Vector2 _bottomLeftCorner;
  private HashSet<TileType> _playerMovementTiles = new HashSet<TileType>() {
    TileType.Empty,
    TileType.Entrance,
    TileType.Goal
  };
  private HashSet<TileType> _monsterMovementTiles = new HashSet<TileType>() {
    TileType.Empty,
    TileType.Entrance
  };

  // interface
  public bool CanMoveTo(Vector2 position) {
    TileType tileType;
    return (_map.TryGetValue(position, out tileType)) && (_playerMovementTiles.Contains(tileType));
  }

  public bool MonstersCanMoveTo(Vector2 position) {
    TileType tileType;
    return (_map.TryGetValue(position, out tileType)) && (_monsterMovementTiles.Contains(tileType));
  }

  public bool IsGoal(Vector2 position) {
    TileType tileType;
    return (_map.TryGetValue(position, out tileType)) && (tileType == TileType.Goal);
  }

  public bool AddObjectToMap(Vector2 position, TileType tileType) {
    if (!_map.ContainsKey(position)) {
      UpdateMapSize(position);
      _map.Add(position, tileType);
      return true;
    } else {
      Debug.Log("Error: Failed to add tile to map, as there is already a tile in position " + position);
      return false;
    }
  }

  // implementation
  private void UpdateMapSize(Vector2 newTilePosition) {
    if (_map.Count == 0) {
      _topRightCorner = newTilePosition;
      _bottomLeftCorner = newTilePosition;
    } else {
      if (newTilePosition.x > _topRightCorner.x) {
        _topRightCorner.x = newTilePosition.x;
      } else if (newTilePosition.x < _bottomLeftCorner.x) {
        _bottomLeftCorner.x = newTilePosition.x;
      }
      if (newTilePosition.y > _topRightCorner.y) {
        _topRightCorner.y = newTilePosition.y;
      } else if (newTilePosition.y < _bottomLeftCorner.y) {
        _bottomLeftCorner.y = newTilePosition.y;
      }
    }
  }
}

public enum TileType {
  Empty,
  Entrance,
  Goal,
  Obstacle
}