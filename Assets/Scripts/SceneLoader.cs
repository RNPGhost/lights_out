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
    "Circuit",
    "Corridors",
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
      _levelName = _levelNames[levelNumber - 1];
    }
    LoadLevelScene();
  }

  public static void LoadNextLevel() {
    if (_levelNumber < _levelNames.Length) {
      _levelNumber++;
      _levelName = _levelNames[_levelNumber - 1];
    }
    LoadLevelScene();
  }

  public static void ReloadLevel() {
    LoadLevelScene();
  }

  public static string GetLevelName() {
    return _levelName;
  }

  public static void LoadMenuScene() {
    SceneManager.LoadScene(_menuSceneName);
  }

  // implementation
  private static void LoadLevelScene() {
    SceneManager.LoadScene(_levelSceneName);
  }
}