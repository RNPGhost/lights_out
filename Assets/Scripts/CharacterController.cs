using UnityEngine;

public class CharacterController : MonoBehaviour {
  // set in editor
  public float speed;

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
    _characterObjectMover = new GameObjectMover(this, gameObject, FindObjectOfType<Map>().GetMapSize(), speed);
  }

  // implementation
  protected Vector2 GetPosition() {
    return _characterPosition;
  }

  private void Update() {
    _characterObjectMover.Update();
  }
}
