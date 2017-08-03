using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour {
  // interface
  public void Clicked() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
