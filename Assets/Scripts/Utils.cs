using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {
  public const float WORLD_SCALE = 2;

  public static Vector3 ConvertToWorldPosition(Vector2 mapPosition, Vector2 mapSize) {
    float x = (mapPosition.x - (mapSize.x - 1) / 2) * WORLD_SCALE;
    float y = 0;
    float z = (mapPosition.y - (mapSize.y - 1) / 2) * WORLD_SCALE;
    return new Vector3(x, y, z);
  }
}
