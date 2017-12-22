﻿using UnityEngine;

public class LevelLockController : MonoBehaviour {
  // interface
  public static void UnlockNextLevel() {
    if (SceneLoader.HasNextLevel()) {
      ProgressState.SetProgressState(SceneLoader.GetNextLevelName(), ProgressState.Unlocked);
    }
  }

  // initialisation
  private void Awake() {
    if (PlayerPrefs.GetString("LevelsInitialised") != "True") {
      foreach (string levelName in SceneLoader.GetLevelNames()) {
        ProgressState.SetProgressState(levelName, ProgressState.Locked);
      }
      ProgressState.SetProgressState(SceneLoader.GetLevelName(1), ProgressState.Unlocked);
      PlayerPrefs.SetString("LevelsInitialised", "True");
    }
  }
}
