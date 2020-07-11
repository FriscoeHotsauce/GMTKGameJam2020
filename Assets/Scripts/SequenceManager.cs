using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{

  public int maxHistorySize = 10;
  public enum ButtonPressed
  {
    purpleCircle, blueCircle, orangeCircle, greenCircle,
    purpleSquare, blueSquare, orangeSquare, greenSquare
  }

  public enum SliderValue
  {
    purpleSlider, blueSlider, orangeSlider, greenSlider
  }

  public enum ToggleValue
  {
    purpleToggle, blueToggle, orangeToggle, greenToggle
  }

  public List<Task> taskList;
  public List<ButtonHistory> buttonHistory;

  // Start is called before the first frame update
  void Start()
  {
    buttonHistory = new List<ButtonHistory>();
    taskList = new List<Task>();
  }

  public void generateNewTask()
  {
    taskList.Insert(0, new SingleTask(ButtonPressed.blueCircle, Time.time));
  }

  public void evaluteAllTasks()
  {
    List<Task> updatedTaskList = new List<Task>();
    foreach (Task task in taskList)
    {
      if (task.evaluate(buttonHistory, Time.time))
      {
        Debug.Log("Task completed successfully for " + task.score() + " points");

      }
      else
      {
        updatedTaskList.Add(task);
      }
    }
    taskList = updatedTaskList;
  }

  public List<ButtonHistory> getButtonSequence(int size)
  {
    return buttonHistory.GetRange(0, size);
  }

  public void addButtonToHistory(ButtonPressed pressed)
  {
    Debug.Log("Adding " + pressed.ToString() + " to the queue");
    buttonHistory.Insert(0, new ButtonHistory(pressed, Time.time));
    if (buttonHistory.Count > maxHistorySize)
    {
      ButtonHistory dequeued = buttonHistory[maxHistorySize];
      buttonHistory.RemoveAt(maxHistorySize);
      Debug.Log(dequeued.ToString() + " was bumped from the queue");
    }
  }

  public void addPurpleCircleButtonPress()
  {
    addButtonToHistory(ButtonPressed.purpleCircle);
  }

  public void addBlueCircleButtonPress()
  {
    addButtonToHistory(ButtonPressed.blueCircle);
  }

  public void addOrangeCircleButtonPress()
  {
    addButtonToHistory(ButtonPressed.orangeCircle);
  }

  public void addGreenCircleButtonPress()
  {
    addButtonToHistory(ButtonPressed.greenCircle);
  }

  public void addPurpleSquareButtonPress()
  {
    addButtonToHistory(ButtonPressed.purpleSquare);
  }

  public void addBlueSquareButtonPress()
  {
    addButtonToHistory(ButtonPressed.blueSquare);
  }

  public void addOrangeSquareButtonPress()
  {
    addButtonToHistory(ButtonPressed.orangeSquare);
  }

  public void addGreenSquareButtonPress()
  {
    addButtonToHistory(ButtonPressed.greenSquare);
  }
}

public class ButtonHistory
{

  public float time;
  public SequenceManager.ButtonPressed buttonPressed;

  public ButtonHistory(SequenceManager.ButtonPressed buttonPressed, float time)
  {
    this.buttonPressed = buttonPressed;
    this.time = time;
  }

  public SequenceManager.ButtonPressed getButtonPressed()
  {
    return buttonPressed;
  }

  public float getTime()
  {
    return time;
  }
}
