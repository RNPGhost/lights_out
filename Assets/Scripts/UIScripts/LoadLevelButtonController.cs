using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButtonController : MonoBehaviour {
  // interface
  public void SetLevelAndStart(string levelName) {
    Utils._levelName = levelName;
    LoadLevel();
  }

  public void RestartLevel() {
    LoadLevel();
  }

  // implementation
  private void LoadLevel() {
    SceneManager.LoadScene(Utils._levelSceneName);
  }
}
