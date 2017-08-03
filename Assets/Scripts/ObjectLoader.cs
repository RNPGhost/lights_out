﻿using UnityEngine;

public class ObjectLoader {
  // references
  private Map _map;

  // state
  private Tile[] _tiles = new Tile[] {
    new Tile(GetTilePrefab("Entrance"), new Vector2(0, 0), TileType.Entrance),
    new Tile(GetTilePrefab("Goal"), new Vector2(0, 5), TileType.Goal),
    new Tile(GetTilePrefab("Empty"), new Vector2(0, 1), TileType.Empty),
    new Tile(GetTilePrefab("Empty"), new Vector2(0, 2), TileType.Empty),
    new Tile(GetTilePrefab("Empty"), new Vector2(0, 3), TileType.Empty),
    new Tile(GetTilePrefab("Empty"), new Vector2(0, 4), TileType.Empty),
    new Tile(GetTilePrefab("Box"), new Vector2(1, 4), TileType.Obstacle)
  };
  private Monster[] _monsters = new Monster[] {
    new Monster(GetMonsterPrefab("Udwin"), new Vector2(0, 4))
  };
  private Player _player = new Player(GetPlayerPrefab("Sam"));
  private Tile _entranceTile;

  // interface
  public ObjectLoader(Map map) {
    _map = map;
    LoadTiles();
    LoadMonsters();
    LoadPlayer();
  }

  // implementation
  private void LoadTiles() {
    foreach (Tile tile in _tiles) {
      if (tile.GameObject == null || tile.Position == null) {
        Debug.Log("Error: Failed to load tile with properties: GameObject = " + tile.GameObject + ", Position = " + tile.Position + ", TileType = " + tile.TileType);
        continue;
      }

      if (_map.AddObjectToMap(tile.Position, tile.TileType)) {
        Object.Instantiate(tile.GameObject, Utils.ConvertToWorldPosition(tile.Position), tile.GameObject.transform.rotation);
        if (tile.TileType == TileType.Entrance) {
          _entranceTile = tile;
        }
      }
    }
  }

  private void LoadMonsters() {
    foreach (Monster monster in _monsters) {
      if (monster.GameObject == null || monster.Position == null) {
        Debug.Log("Error: Failed to load monster with properties: GameObject = " + monster.GameObject + ", Position = " + monster.Position);
        continue;
      }

      Object.Instantiate(monster.GameObject, Utils.ConvertToWorldPosition(monster.Position), monster.GameObject.transform.rotation);
    }
  }

  private void LoadPlayer() {
    if (_entranceTile.GameObject == null) {
      Debug.Log("Error: Failed to load player as a valid entrance tile was not found in list of tiles: GameObject = " + _entranceTile.GameObject);
    }
    if (_player.GameObject == null) {
      Debug.Log("Error: Failed to load player with properties: GameObject = " + _player.GameObject);
    }

    Object.Instantiate(_player.GameObject, Utils.ConvertToWorldPosition(_entranceTile.Position), _entranceTile.GameObject.transform.rotation);
  }

  private static GameObject GetMonsterPrefab(string name) {
    string monstersPath = "Monsters/";
    return LoadPrefab(monstersPath + name);
  }

  private static GameObject GetTilePrefab(string name) {
    string tilesPath = "Tiles/";
    return LoadPrefab(tilesPath + name);
  }

  private static GameObject GetPlayerPrefab(string name) {
    string playerPath = "Players/";
    return LoadPrefab(playerPath + name);
  }

  private static GameObject LoadPrefab(string path) {
    return (GameObject)Resources.Load(path, typeof(GameObject));
  }
}

public struct Tile {
  public GameObject GameObject;
  public Vector2 Position;
  public TileType TileType;

  public Tile(GameObject gameObject, Vector2 position, TileType tileType) {
    GameObject = gameObject;
    Position = position;
    TileType = tileType;
  }
}

public struct Monster {
  public GameObject GameObject;
  public Vector2 Position;

  public Monster(GameObject gameObject, Vector2 position) {
    GameObject = gameObject;
    Position = position;
  }
}

public struct Player {
  public GameObject GameObject;

  public Player(GameObject gameObject) {
    GameObject = gameObject;
  }
}
