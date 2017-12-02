using UnityEngine;

public class LoadLevelButtonController : MonoBehaviour {
  // interface
  public void SetLevelAndStart(int levelNumber) {
    SceneLoader.SelectLevel(levelNumber);
    LoadLevel();
  }

  public void RestartLevel() {
    LoadLevel();
  }

  // implementation
  private void LoadLevel() {
    SceneLoader.LoadLevelScene();
  }
}
