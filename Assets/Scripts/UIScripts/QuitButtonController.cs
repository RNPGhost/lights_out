using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonController : MonoBehaviour {
  // interface
  public void Clicked() {
    Application.Quit();
  }
}
