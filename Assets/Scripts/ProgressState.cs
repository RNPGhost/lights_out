public class ProgressState {
  public static readonly ProgressState Complete = new ProgressState("Complete");
  public static readonly ProgressState Optimal = new ProgressState("Optimal");

  private string _stateDescription;

  internal ProgressState(string stateDescription) {
    _stateDescription = stateDescription;
  }

  override public string ToString() {
    return _stateDescription;
  }
}
