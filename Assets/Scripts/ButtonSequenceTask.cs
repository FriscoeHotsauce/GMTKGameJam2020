using System.Collections.Generic;

public class ButtonSequenceTask : Task
{
  private List<SequenceManager.ButtonPressed> buttonSequence;
  private float createdAt;

  public ButtonSequenceTask(List<SequenceManager.ButtonPressed> buttonSequence, float createdAt)
  {
    this.buttonSequence = buttonSequence;
    this.createdAt = createdAt;
  }

  public bool evaluate(List<ButtonHistory> buttonHistory, float time)
  {
    return true;
  }

  public int score()
  {
    return buttonSequence.Count;
  }

  public float timeGenerated()
  {
    return createdAt;
  }
}
