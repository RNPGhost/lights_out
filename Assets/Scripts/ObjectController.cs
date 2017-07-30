using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
  // set in editor
  public Vector2 _position;
  public TileType _tileType;

  // references
  private Vector2 _mapSize;

  // interface
  public Vector2 GetPosition() {
    return _position;
  }

  public TileType GetTileType() {
    return _tileType;
  }

  // initialisation
  private void Awake() {
    _mapSize = FindObjectOfType<Map>().GetMapSize();
  }

  private void Start() {
    SetPosition(_position);
  }

  // implementation
  public void SetPosition(Vector2 position) {
    gameObject.transform.position = Utils.ConvertToWorldPosition(position, _mapSize);
  }
}
