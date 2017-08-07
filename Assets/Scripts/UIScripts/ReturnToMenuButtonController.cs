using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnToMenuButtonController : MonoBehaviour {
  // interface
  public void Clicked() {
    SceneManager.LoadScene(Utils._menuSceneName);
  }
}
