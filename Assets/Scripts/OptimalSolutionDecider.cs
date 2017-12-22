using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptimalSolutionDecider {

  public static int GetOptimalNumberOfMoves(string levelName) {
    int moves;
    optimalLevelMoveCount.TryGetValue(levelName, out moves);
    return moves;
  }

  // implementation
  private static readonly Dictionary<string, int> optimalLevelMoveCount = new Dictionary<string, int>() {
    { "Maze", 17 },
    { "Gallery", 12 },
    { "Corridors", 23 },
    { "Elevators", 26 },
    { "DoubleTrouble", 20 },
    { "Circuit", 12 },
    { "TwosCompany", 11 },
    { "X-Wing", 10 },
    { "Vendetta", 13 },
    { "Patrol", 9 },
    { "Batarang", 24 },
    { "Batcave", 11 }
  };
}
