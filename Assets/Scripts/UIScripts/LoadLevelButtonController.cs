using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButtonController : MonoBehaviour {
  // set in editor
  public string _levelName;

  // interface
  public void Clicked() {
    Utils._levelName = _levelName;
    SceneManager.LoadScene(Utils._levelSceneName);
  }
}
