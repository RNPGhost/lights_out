using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
  // state
  private static string _levelName;
  private static int _levelNumber;
  private static string _levelSceneName = "level";
  private static string _menuSceneName = "menu";
  private static string[] _levelNames = {
    "Maze",
    "Gallery",
    "Corridors",
    "Elevators",
    "DoubleTrouble",
    "Circuit",
    "TwosCompany",
    "X-Wing",
    "Vendetta",
    "Patrol",
    "Batarang",
    "Batcave",
  };

  // interface
  public static void LoadLevel(int levelNumber) {
    if (levelNumber > 0 && levelNumber <= _levelNames.Length) {
      _levelNumber = levelNumber;
      UpdateLevelName();
      LoadLevelScene();
    }
  }

  public static void LoadNextLevel() {
    if (_levelNumber < _levelNames.Length) {
      _levelNumber++;
      UpdateLevelName();
      LoadLevelScene();
    }
    else {
      LoadMenuScene();
    }
  }

  public static void ReloadLevel() {
    LoadLevelScene();
  }

  public static string GetLevelName() {
    if (_levelName == null) {
      _levelNumber = 1;
      UpdateLevelName();
    }
    return _levelName;
  }

  public static void LoadMenuScene() {
    SceneManager.LoadScene(_menuSceneName);
  }

  // implementation
  private static void LoadLevelScene() {
    SceneManager.LoadScene(_levelSceneName);
  }

  private static void UpdateLevelName() {
    _levelName = _levelNames[_levelNumber - 1];
  }
}