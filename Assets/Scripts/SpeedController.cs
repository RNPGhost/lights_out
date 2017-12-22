using UnityEngine;

public static class SpeedController {
  // constants
  private static readonly SpeedMode[] _movementSpeedModes = {
    new SpeedMode(1, "Terrified"),
    new SpeedMode(1.5f, "Cautious"),
    new SpeedMode(2, "Fearless")
  };

  // state
  private static int _movementSpeedModeIndex = PlayerPrefs.GetInt("PlayerSpeed");

  // interface
  public static float GetMovementSpeed() {
    return _movementSpeedModes[_movementSpeedModeIndex].Speed;
  }

  public static string GetMovementSpeedText() {
    return _movementSpeedModes[_movementSpeedModeIndex].SpeedText;
  }

  public static void ChangeSpeed() {
    _movementSpeedModeIndex = (_movementSpeedModeIndex + 1) % _movementSpeedModes.Length;
    PlayerPrefs.SetInt("PlayerSpeed", _movementSpeedModeIndex);
  }


  // implementation
  private struct SpeedMode {
    public float Speed;
    public string SpeedText;

    public SpeedMode(float speed, string speedText) {
      Speed = speed;
      SpeedText = speedText;
    }
  }
}
