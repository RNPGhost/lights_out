using UnityEngine;
using System.Collections.Generic;

public static class Utils {
  // constants
  private const float WORLD_SCALE = 2;
  private const float MOVEMENT_TIME = 1;

  // state
  private static string _playerTag = "Player";
  private static string _levelName;
  private static string _levelSceneName = "level";
  private static string _menuSceneName = "menu";
  private static string[] _levelNames = {
    "Maze",
    "Gallery",
    "Circuit",
    "Corridors",
    "TwosCompany",
    "X-Wing",
    "Batarang",
    "Vendetta",
    "Patrol",
    "Batcave",
  };

  // interface
  public static void SelectLevel(int levelNumber) {
    if (levelNumber > 0 && levelNumber <= _levelNames.Length) {
      _levelName = _levelNames[levelNumber - 1];
    }
  }

  public static string GetLevelName() {
    return _levelName;
  }

  public static string GetLevelSceneName() {
    return _levelSceneName;
  }

  public static string GetMenuSceneName() {
    return _menuSceneName;
  }

  public static string GetPlayerTag() {
    return _playerTag;
  }

  public static Vector3 ConvertToWorldPosition(Vector2 mapPosition) {
    float x = mapPosition.x * WORLD_SCALE;
    float y = 0;
    float z = mapPosition.y * WORLD_SCALE;
    return new Vector3(x, y, z);
  }

  public static Vector2 ConvertToMapPosition(Vector3 worldPosition) {
    int x = (int)(worldPosition.x / WORLD_SCALE);
    int y = (int)(worldPosition.z / WORLD_SCALE);
    return new Vector2(x, y);
  }

  public static float GetCharacterSpeed(float pathLength) {
    return (pathLength * WORLD_SCALE) / MOVEMENT_TIME;
  }

  public static Vector2 GetDirectionRelativeToGameObjectForwards(Vector2 mapDirection, GameObject gameObject) {
    Vector3 worldDirection = mapDirection.y * gameObject.transform.forward + mapDirection.x * gameObject.transform.right;
    return ConvertToMapDirection(worldDirection);
  }

  public static Quaternion LookRotation(Vector2 mapDirection) {
    return Quaternion.LookRotation(ConvertToWorldDirection(mapDirection));
  }

  private static Vector3 ConvertToWorldDirection(Vector2 mapDirection) {
    return new Vector3(mapDirection.x, 0, mapDirection.y);
  }

  private static Vector2 ConvertToMapDirection(Vector3 worldDirection) {
    return new Vector2(worldDirection.x, worldDirection.z);
  }
}
