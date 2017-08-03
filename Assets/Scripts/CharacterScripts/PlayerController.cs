using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController {
  // state
  private HashSet<TileType> _permittedMovementTiles;

  // implementation
  protected override void CreatePath(Vector2 playerTargetPosition) {
    AddTargetToPath(playerTargetPosition);
  }

  protected override HashSet<TileType> GetPermittedMovementTiles() {
    if (_permittedMovementTiles == null) {
      _permittedMovementTiles = base.GetPermittedMovementTiles();
      _permittedMovementTiles.Add(TileType.Goal);
    }
    return _permittedMovementTiles;
  }
}