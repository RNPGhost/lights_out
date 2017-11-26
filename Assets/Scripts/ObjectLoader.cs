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
  private Tile _entranceTile;

  // interface
  public ObjectLoader(Map map, string levelName) {
    _map = map;
    LoadLevelObjects(levelName);
  }

  // implementation
  private void LoadLevelObjects(string levelName) {
    string jsonText = Resources.Load<TextAsset>(LEVELS_PATH + levelName).text;
    GameObjectsContainer loadedObjectContainer = JsonUtility.FromJson<GameObjectsContainer>(jsonText);
    LoadTiles(loadedObjectContainer.tiles);
    LoadMonsters(loadedObjectContainer.monsters);
    LoadPlayer(loadedObjectContainer.player);
  }

  private void LoadTiles(Tile[] tiles) {
    foreach (Tile tile in tiles) {
      GameObject tilePrefab = LoadPrefab(TILES_PATH + tile.prefabName);
      if (tilePrefab == null) {
        continue;
      }

      TileType tileType;
      try {
        tileType = (TileType)Enum.Parse(typeof(TileType), tile.tileType);
      }
      catch {
        Debug.Log("Error: Failed to load tile " + tile.tileType + " is not a valid tile type");
        continue;
      }

      if (_map.AddObjectToMap(tile.position, tileType)) {
        UnityEngine.Object.Instantiate(tilePrefab, Utils.ConvertToWorldPosition(tile.position), Utils.LookRotation(tile.direction));

        if (tileType == TileType.Entrance) {
          if (_entranceTile.prefabName != null) {
            Debug.Log("Error: Multiple entrance tiles loaded");
          } else {
            _entranceTile = tile;
          }
        }
      }
    }
  }

  private void LoadMonsters(Monster[] monsters) {
    foreach (Monster monster in monsters) {
      GameObject monsterPrefab = LoadPrefab(MONSTERS_PATH + monster.prefabName);
      if (monsterPrefab == null) {
        continue;
      }

      GameObject monsterInstance = UnityEngine.Object.Instantiate(monsterPrefab, Utils.ConvertToWorldPosition(monster.position), Utils.LookRotation(monster.direction));
      MonsterController monsterController = monsterInstance.GetComponent<MonsterController>();
      if (monsterController is SingleStepMonsterController) {
        ((SingleStepMonsterController) monsterController).SetStartDirection(monster.direction);
      }
    }
  }

  private void LoadPlayer(Player player) {
    if (_entranceTile.prefabName == null) {
      Debug.Log("Error: Failed to load player as no valid entrance tile was loaded");
    }
    if (player.prefabName == null) {
      Debug.Log("Error: Failed to load player as no object of type player was loaded");
    }

    GameObject playerPrefab = LoadPrefab(PLAYERS_PATH + player.prefabName);
    if (playerPrefab == null) {
      return;
    }

    UnityEngine.Object.Instantiate(playerPrefab, Utils.ConvertToWorldPosition(_entranceTile.position), Utils.LookRotation(_entranceTile.direction));
  }

  private static GameObject LoadPrefab(string path) {
    GameObject gameObject = (GameObject)Resources.Load(path, typeof(GameObject));
    return gameObject;
  }
}

[Serializable]
public struct GameObjectsContainer {
  public Tile[] tiles;
  public Monster[] monsters;
  public Player player;
}

[Serializable]
public struct Player {
  public string prefabName;
}

[Serializable]
public struct Monster {
  public string prefabName;
  public Vector2 position;
  public Vector2 direction;
}

[Serializable]
public struct Tile {
  public string prefabName;
  public string tileType;
  public Vector2 position;
  public Vector2 direction;
}