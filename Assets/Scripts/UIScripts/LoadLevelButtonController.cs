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
    string levelName = SceneLoader.GetLevelName(_levelNumber);
    if (ProgressState.Optimal.IsStateOf(levelName)) {
      SetButtonColour(button, _completeOptimallyColour);
    }
    else if (ProgressState.Complete.IsStateOf(levelName)) {
      SetButtonColour(button, _completeColour);
    }
    else if (ProgressState.Locked.IsStateOf(levelName)) {
      button.interactable = false;
    }
  }

  private void SetButtonColour(Button button, Color newColour) {
    ColorBlock colourBlock = button.colors;
    colourBlock.normalColor = newColour;
    colourBlock.highlightedColor = newColour;
    button.colors = colourBlock;
  }
}
