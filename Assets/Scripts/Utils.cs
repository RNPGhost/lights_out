using UnityEngine;

public static class Utils {
  // constants
  private const float WORLD_SCALE = 2;
  private const float MOVEMENT_TIME = 1;

  // interface
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
}
