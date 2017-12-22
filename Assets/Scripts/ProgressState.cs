using UnityEngine;

public class ProgressState {
  public static readonly ProgressState Locked = new ProgressState("Locked");
  public static readonly ProgressState Unlocked = new ProgressState("Unlocked");
  public static readonly ProgressState Complete = new ProgressState("Complete");
  public static readonly ProgressState Optimal = new ProgressState("Optimal");

  private string _stateDescription;

  internal ProgressState(string stateDescription) {
    _stateDescription = stateDescription;
  }

  override public string ToString() {
    return _stateDescription;
  }

  public static void SetProgressState(string levelName, ProgressState progressState) {
    PlayerPrefs.SetString(levelName, progressState.ToString());
  }

  public bool IsStateOf(string levelName) {
    return this.ToString() == PlayerPrefs.GetString(levelName);
  }
}
