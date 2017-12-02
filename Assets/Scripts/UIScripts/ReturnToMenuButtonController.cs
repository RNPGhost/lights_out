using UnityEngine;

public class ReturnToMenuButtonController : MonoBehaviour {
  // interface
  public void Clicked() {
    SceneLoader.LoadLevelScene();
  }
}
