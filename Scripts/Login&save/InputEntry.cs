using System;

[Serializable]
public class InputEntry {
    public string playerName;
    public int level;
    public int points;
  public int score;
    public InputEntry (string name, int level,int points,int score) {
        playerName = name;
        this.level = level;
    this.points=points;
    this.score=score;
    }
}

