using System.Collections.Generic;

public class SingleTask : Task
{

  private float createdAt;
  private ButtonPressed buttonToPress;
  private string id;

  public SingleTask(ButtonPressed buttonToPress, float createdAt)
  {
    this.buttonToPress = buttonToPress;
    this.createdAt = createdAt;
    this.id = System.Guid.NewGuid().ToString();
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

  public string getId()
  {
    return id;
  }

  public ButtonPressed getButtonToPress()
  {
    return buttonToPress;
  }
}
