using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
  // state
  private static string _levelName;
  private static string _levelSceneName = "level";
  private static string _menuSceneName = "menu";
  private static string[] _levelNames = {
    "Maze",
    "Gallery",
    "Circuit",
    "Corridors",
    "TwosCompany",
    "X-Wing",
    "Batarang",
    "Vendetta",
    "Patrol",
    "Batcave",
  };

  // interface
  public static void SelectLevel(int levelNumber) {
    if (levelNumber > 0 && levelNumber <= _levelNames.Length) {
      _levelName = _levelNames[levelNumber - 1];
    }
  }

  public static string GetLevelName() {
    return _levelName;
  }

  public static void LoadLevelScene() {
    SceneManager.LoadScene(_levelSceneName);
  }

  public static void LoadMenuScene() {
    SceneManager.LoadScene(_menuSceneName);
  }
}