using System;
using UnityEngine;

public class ObjectLoader {
  // references
  private Map _map;

  // constants
  private const string LEVELS_PATH = "Levels/";
  private const string PLAYERS_PATH = "Players/";
  private const string MONSTERS_PATH = "Monsters/";
  private const string TILES_PATH = "Tiles/";

  // state
  private Player _player;
  private Tile _entranceTile;

  // interface
  public ObjectLoader(Map map, string levelName) {
    _map = map;
    LoadLevelObjects(levelName);
  }

  // implementation
  private void LoadLevelObjects(string levelName) {
    string jsonText = Resources.Load<TextAsset>(LEVELS_PATH + levelName).text;
    LoadedGameObjects loadedObjectContainer = JsonUtility.FromJson<LoadedGameObjects>(jsonText);
    foreach (LoadedGameObject loadedObject in loadedObjectContainer.objects) {
      switch (loadedObject.objectType) {
        case "Tile":
          LoadTile(new Tile(loadedObject));
          break;
        case "Monster":
          LoadMonster(new Monster(loadedObject));
          break;
        case "Player":
          if (_player.prefabName != null) {
            Debug.Log("Error: Multiple players loaded");
          } else {
            _player = new Player(loadedObject);
          }
          break;
        default:
          Debug.Log("Error: Loaded game object of unknown type: " + loadedObject.objectType);
          break;
      }
    }

    LoadPlayer();
  }

  private void LoadTile(Tile tile) {
    GameObject tilePrefab = LoadPrefab(TILES_PATH + tile.prefabName);
    if (tilePrefab == null) {
      return;
    }

    if (_map.AddObjectToMap(tile.position, tile.tileType)) {
      UnityEngine.Object.Instantiate(tilePrefab, Utils.ConvertToWorldPosition(tile.position), tilePrefab.transform.rotation);

      if (tile.tileType == TileType.Entrance) {
        if (_entranceTile.prefabName != null) {
          Debug.Log("Error: Multiple entrance tiles loaded");
        } else {
          _entranceTile = tile;
        }
      }
    }
  }

  private void LoadMonster(Monster monster) {
    GameObject monsterPrefab = LoadPrefab(MONSTERS_PATH + monster.prefabName);
    if (monsterPrefab == null) {
      return;
    }

    UnityEngine.Object.Instantiate(monsterPrefab, Utils.ConvertToWorldPosition(monster.position), monster.rotation);
  }

  private void LoadPlayer() {
    if (_entranceTile.prefabName == null) {
      Debug.Log("Error: Failed to load player as no valid entrance tile was loaded");
    }
    if (_player.prefabName == null) {
      Debug.Log("Error: Failed to load player as no object of type player was loaded");
    }

    GameObject playerPrefab = LoadPrefab(PLAYERS_PATH + _player.prefabName);
    if (playerPrefab == null) {
      return;
    }

    UnityEngine.Object.Instantiate(playerPrefab, Utils.ConvertToWorldPosition(_entranceTile.position), _entranceTile.rotation);
  }

  private static GameObject LoadPrefab(string path) {
    GameObject gameObject = (GameObject)Resources.Load(path, typeof(GameObject));
    return gameObject;
  }
}

[Serializable]
public struct LoadedGameObjects {
  public LoadedGameObject[] objects;
}

[Serializable]
public struct LoadedGameObject {
  public string objectType;
  public string prefabName;
  public Vector2 position;
  public Vector2 direction;
  public string tileType;

  public Quaternion GetRotation() {
    return Quaternion.LookRotation(Utils.ConvertToWorldDirection(direction));
  }
}

public struct Player {
  public string prefabName;

  public Player(LoadedGameObject loadedGameObject) {
    prefabName = loadedGameObject.prefabName;
  }
}

public struct Monster {
  public string prefabName;
  public Vector2 position;
  public Quaternion rotation;

  public Monster(LoadedGameObject loadedGameObject) {
    prefabName = loadedGameObject.prefabName;
    position = loadedGameObject.position;
    rotation = loadedGameObject.GetRotation();
  }
}

public struct Tile {
  public string prefabName;
  public Vector2 position;
  public Quaternion rotation;
  public TileType tileType;

  public Tile(LoadedGameObject loadedGameObject) {
    prefabName = loadedGameObject.prefabName;
    position = loadedGameObject.position;
    rotation = loadedGameObject.GetRotation();
    try {
      tileType = (TileType)Enum.Parse(typeof(TileType), loadedGameObject.tileType);
    }
    catch {
      Debug.Log("Error: Failed to load tile " + loadedGameObject.tileType + " is not a valid tile type");
      tileType = TileType.Empty;
    }
  }
}