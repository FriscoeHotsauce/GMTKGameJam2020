using System.Collections.Generic;

public class SingleTask : Task
{

  private float createdAt;
  private SequenceManager.ButtonPressed buttonToPress;

  public SingleTask(SequenceManager.ButtonPressed buttonToPress, float createdAt)
  {
    this.buttonToPress = buttonToPress;
    this.createdAt = createdAt;
  }

  public bool evaluate(List<ButtonHistory> buttonHistory, float time)
  {
    return (buttonHistory[0].getButtonPressed() == buttonToPress) && (buttonHistory[0].getTime() > createdAt);
  }

  public int score()
  {
    return 1;
  }

  public float timeGenerated()
  {
    return createdAt;
  }
}
