using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetConfirmationButtonController : MonoBehaviour {
  // set in editor
  public GameObject _mainCanvas;
  public GameObject _confirmationCanvas;

  // interface
  public void GetConfirmation() {
    _mainCanvas.SetActive(false);
    _confirmationCanvas.SetActive(true);
  }

  public void Cancel() {
    _confirmationCanvas.SetActive(false);
    _mainCanvas.SetActive(true);
  }
}
