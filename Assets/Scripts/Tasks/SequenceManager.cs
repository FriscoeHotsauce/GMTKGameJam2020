using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
  Keep track of which buttons were pressed, the current list of tasks
*/

public enum ButtonPressed
{
  purpleCircle, blueCircle, orangeCircle, greenCircle,
  purpleSquare, blueSquare, orangeSquare, greenSquare,
  purplePower, bluePower, orangePower, greenPower
}

public enum Slider
{
  purpleSlider, blueSlider, orangeSlider, greenSlider
}

public enum ToggleValue
{
  purpleToggle, blueToggle, orangeToggle, greenToggle
}

public class SequenceManager : MonoBehaviour
{


  public int maxTaskSize = 250;
  public int maxHistorySize = 5;

  public List<Task> taskList;
  public List<ButtonHistory> buttonHistory;
  public bool requiresValidation;
  public TaskGenerator taskGenerator;
  public ViewportHandler viewportHandler;
  public ShopManager shopManager;

  // Start is called before the first frame update
  void Start()
  {
    taskGenerator = new TaskGenerator();
    buttonHistory = new List<ButtonHistory>();
    taskList = taskGenerator.generateStartingTasks();
    requiresValidation = false;
    updateTaskList();
  }

  void Update()
  {
    if (requiresValidation)
    {
      evaluateCurrentTask();
      requiresValidation = false;
      updateTaskList();
    }
  }

  public void generateNewTask(Phase currentPhase)
  {
    if (taskList.Count >= maxTaskSize)
    {
      return;
    }

    if (currentPhase == Phase.One)
    {
      taskList.Add(taskGenerator.generatePhaseOneTask(Time.time));
    }
    else if (currentPhase == Phase.Two)
    {
      taskList.Add(taskGenerator.generatePhaseTwoTask(Time.time));
    }
    else
    {
      taskList.Add(taskGenerator.generatePhaseThreeTask(Time.time));

    }
    updateTaskList();
  }

  public void evaluateCurrentTask()
  {
    if (taskList.Count != 0 && taskList[0].evaluate(buttonHistory, Time.time))
    {
      int score = taskList[0].score();
      shopManager.addItemToShop(score);
      taskList.RemoveAt(0);
    }

  }

  //don't plan on using this, evaluating all the tasks was too complex
  public void evaluateAllTasks()
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

  public void clearAllTasks()
  {
    taskList = new List<Task>();
    updateTaskList();
  }

  public List<ButtonHistory> getButtonSequence(int size)
  {
    return buttonHistory.GetRange(0, size);
  }

  public int getTasksRemaining()
  {
    return taskList.Count;
  }

  public void addButtonToHistory(ButtonPressed pressed)
  {
    //Debug.Log("Adding " + pressed.ToString() + " to the queue");
    buttonHistory.Insert(0, new ButtonHistory(pressed, Time.time));
    if (buttonHistory.Count > maxHistorySize)
    {
      ButtonHistory dequeued = buttonHistory[maxHistorySize];
      buttonHistory.RemoveAt(maxHistorySize);
      //Debug.Log(dequeued.ToString() + " was bumped from the queue");
    }
  }

  private void updateTaskList()
  {
    viewportHandler.updateTaskList(taskList);
  }

  public void addPurpleCircleButtonPress()
  {
    addButtonToHistory(ButtonPressed.purpleCircle);
    requiresValidation = true;
  }

  public void addBlueCircleButtonPress()
  {
    addButtonToHistory(ButtonPressed.blueCircle);
    requiresValidation = true;

  }

  public void addOrangeCircleButtonPress()
  {
    addButtonToHistory(ButtonPressed.orangeCircle);
    requiresValidation = true;
  }

  public void addGreenCircleButtonPress()
  {
    addButtonToHistory(ButtonPressed.greenCircle);
    requiresValidation = true;
  }

  public void addPurpleSquareButtonPress()
  {
    addButtonToHistory(ButtonPressed.purpleSquare);
    requiresValidation = true;
  }

  public void addBlueSquareButtonPress()
  {
    addButtonToHistory(ButtonPressed.blueSquare);
    requiresValidation = true;
  }

  public void addOrangeSquareButtonPress()
  {
    addButtonToHistory(ButtonPressed.orangeSquare);
    requiresValidation = true;
  }

  public void addGreenSquareButtonPress()
  {
    addButtonToHistory(ButtonPressed.greenSquare);
    requiresValidation = true;
  }

  public void addPurplePowerButtonPress()
  {
    addButtonToHistory(ButtonPressed.purplePower);
    requiresValidation = true;
  }
  public void addBluePowerButtonPress()
  {
    addButtonToHistory(ButtonPressed.bluePower);
    requiresValidation = true;
  }
  public void addOrangePowerButtonPress()
  {
    addButtonToHistory(ButtonPressed.orangePower);
    requiresValidation = true;
  }
  public void addGreenPowerButtonPress()
  {
    addButtonToHistory(ButtonPressed.greenPower);
    requiresValidation = true;
  }

}

public class ButtonHistory
{

  public float time;
  public ButtonPressed buttonPressed;

  public ButtonHistory(ButtonPressed buttonPressed, float time)
  {
    this.buttonPressed = buttonPressed;
    this.time = time;
  }

  public ButtonPressed getButtonPressed()
  {
    return buttonPressed;
  }

  public float getTime()
  {
    return time;
  }
}
