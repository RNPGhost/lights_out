using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
  // state
  private Vector2 _characterPosition;

  // references
  private GameObjectMover _characterObjectMover;

  // interface
  public void MoveCharacter(Vector2 position) {
    _characterObjectMover.MoveTo(position);
    _characterPosition = position;
  }

  public void SetStartingPosition(Vector2 position) {
    _characterObjectMover.MoveToStartPosition(position);
    _characterPosition = position;
  }

  public virtual void MovementComplete() { }

  // initialisation
  protected virtual void Awake() {
    _characterObjectMover = new GameObjectMover(this, gameObject, FindObjectOfType<Map>().GetMapSize());
  }

  // implementation
  protected Vector2 GetPosition() {
    return _characterPosition;
  }
}
