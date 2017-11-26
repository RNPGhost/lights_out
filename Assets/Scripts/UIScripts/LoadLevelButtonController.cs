using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButtonController : MonoBehaviour {
  // interface
  public void SetLevelAndStart(int levelNumber) {
    Utils.SelectLevel(levelNumber);
    LoadLevel();
  }

  public void RestartLevel() {
    LoadLevel();
  }

  // implementation
  private void LoadLevel() {
    SceneManager.LoadScene(Utils.GetLevelSceneName());
  }
}
