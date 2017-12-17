using UnityEngine;

public class LoadLevelButtonController : MonoBehaviour {
  // interface
  public void LoadLevel(int levelNumber) {
    SceneLoader.LoadLevel(levelNumber);
  }

  public void RestartLevel() {
    SceneLoader.ReloadLevel();
  }

  public void LoadNextLevel() {
    SceneLoader.LoadNextLevel();
  }
}
