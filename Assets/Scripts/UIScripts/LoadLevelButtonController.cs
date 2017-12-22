using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButtonController : MonoBehaviour {
  // set in editor
  public int _levelNumber;
  public Color _completeColour;
  public Color _completeOptimallyColour;

  // interface
  public void LoadLevel() {
    SceneLoader.LoadLevel(_levelNumber);
  }

  public void RestartLevel() {
    SceneLoader.ReloadLevel();
  }

  public void LoadNextLevel() {
    SceneLoader.LoadNextLevel();
  }

  // implementation
  private void Start() {
    Button button = GetComponent<Button>();
    if (PlayerPrefs.GetString(SceneLoader.GetLevelName(_levelNumber)) == ProgressState.Complete.ToString()) {
      SetButtonColour(button, _completeColour);
    }
    else if (PlayerPrefs.GetString(SceneLoader.GetLevelName(_levelNumber)) == ProgressState.Optimal.ToString()) {
      SetButtonColour(button, _completeOptimallyColour);
    }
  }

  private void SetButtonColour(Button button, Color newColour) {
    ColorBlock colourBlock = button.colors;
    colourBlock.normalColor = newColour;
    colourBlock.highlightedColor = newColour;
    button.colors = colourBlock;
  }
}
