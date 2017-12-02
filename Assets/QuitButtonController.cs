using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonController : MonoBehaviour {
  // set in editor
  public GameObject _mainCanvas;
  public GameObject _confirmQuitCanvas;
  
  // interface
  public void Quit() {
    _mainCanvas.SetActive(false);
    _confirmQuitCanvas.SetActive(true);
  }

  public void ConfirmQuit() {
    Application.Quit();
  }

  public void CancelQuit() {
    _confirmQuitCanvas.SetActive(false);
    _mainCanvas.SetActive(true);
  }
}
