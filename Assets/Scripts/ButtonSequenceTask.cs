using System.Collections.Generic;

public class ButtonSequenceTask : Task
{
  private List<ButtonPressed> buttonSequence;
  private float createdAt;
  private string id;

  public ButtonSequenceTask(List<ButtonPressed> buttonSequence, float createdAt)
  {
    this.buttonSequence = buttonSequence;
    this.createdAt = createdAt;
    this.id = System.Guid.NewGuid().ToString();
  }

  public bool evaluate(List<ButtonHistory> buttonHistory, float time)
  {
    int completed = 0;
    for (int i = 0; i < buttonSequence.Count; i++)
    {
      if (buttonSequence[i] == buttonHistory[i].getButtonPressed())
      {
        completed += 1;
      }
    }
    return completed == buttonSequence.Count;
  }

  public int score()
  {
    return buttonSequence.Count;
  }

  public float timeGenerated()
  {
    return createdAt;
  }

  public string getId()
  {
    return id;
  }
  public List<ButtonPressed> getButtonSequence()
  {
    return buttonSequence;
  }
}
