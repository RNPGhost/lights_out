﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour {
  public void Clicked() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
