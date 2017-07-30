﻿using UnityEngine;

public class CharacterController : MonoBehaviour {
  // set in editor
  public float speed;

  // state
  private Vector2 _characterPosition;

  // references
  private Map _map;
  private GameController _gameController;
  private GameObjectMover _characterObjectMover;

  // interface
  public void MoveCharacter(Vector2 position) {
    _characterObjectMover.MoveTo(position, speed);
    _characterPosition = position;
  }

  public void SetStartingPosition(Vector2 position) {
    _characterObjectMover.MoveToStartPosition(position);
    _characterPosition = position;
  }

  public virtual void MovementComplete() { }

  // initialisation
  protected virtual void Awake() {
    _map = FindObjectOfType<Map>();
    _gameController = FindObjectOfType<GameController>();
    _characterObjectMover = new GameObjectMover(this, gameObject, FindObjectOfType<Map>().GetMapSize());
  }

  // implementation

  protected bool CanMoveTo(Vector2 position) {
    return _map.CanMoveTo(position);
  }

  protected Vector2 GetPosition() {
    return _characterPosition;
  }

  protected Map GetMap() {
    return _map;
  }

  protected GameController GetGameController() {
    return _gameController;
  }

  private void Update() {
    _characterObjectMover.Update();
  }
}
