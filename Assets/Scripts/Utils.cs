using UnityEngine;

public static class Utils {
  public const float WORLD_SCALE = 2;

  public static Vector3 ConvertToWorldPosition(Vector2 mapPosition) {
    float x = mapPosition.x * WORLD_SCALE;
    float y = 0;
    float z = mapPosition.y * WORLD_SCALE;
    return new Vector3(x, y, z);
  }
}
