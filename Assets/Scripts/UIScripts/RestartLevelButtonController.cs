using UnityEngine;

public class RestartLevelButtonController : MonoBehaviour {
  public void RestartLevel() {
    SceneLoader.ReloadLevel();
  }
}
