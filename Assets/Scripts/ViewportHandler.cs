using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportHandler : MonoBehaviour
{
  public GameObject simpleTaskPrefab;
  public GameObject sliderTaskPrefab;
  public Transform content;

  List<GameObject> taskPanels;

  void Start()
  {
    taskPanels = new List<GameObject>();
    //updateTaskList();
  }

  public void updateTaskList(List<Task> taskList)
  {
    clearChildren();
    taskPanels = new List<GameObject>();
    // for (int i = 0; i < 10; i++)
    // {
    //   GameObject panel = Instantiate(simpleTaskPrefab) as GameObject;
    //   panel.transform.SetParent(content, false);
    // }
    foreach (Task task in taskList)
    {
      if (task is SingleTask || task is ButtonSequenceTask)
      {
        if (task is SingleTask)
        {
          List<ButtonPressed> buttons = new List<ButtonPressed>();
          buttons.Add(((SingleTask)task).getButtonToPress());
          instantiateSimpleTask(buttons);
        }
        else
        {
          List<ButtonPressed> buttons = new List<ButtonPressed>();
          buttons = ((ButtonSequenceTask)task).getButtonSequence();
          instantiateSimpleTask(buttons);
        }
      }
      else if (task is SliderTask)
      {
        SliderTask sliderTask = (SliderTask)task;
        instantiateSliderTask(sliderTask.getSliderToModify(), sliderTask.getExpectedPowerLevel());
      }
    }
  }

  private void instantiateSimpleTask(List<ButtonPressed> buttons)
  {
    GameObject panel = Instantiate(simpleTaskPrefab, content, false) as GameObject;
    TaskPanelController controller = panel.GetComponent<TaskPanelController>();
    controller.setButtons(buttons);
    //panel.transform.SetParent(content, false);
  }

  private void instantiateSliderTask(Slider slider, int powerlevel)
  {
    GameObject panel = Instantiate(sliderTaskPrefab, content, false) as GameObject;
    PowerTaskPanelController controller = panel.GetComponent<PowerTaskPanelController>();
    controller.setPanel(slider, powerlevel);
    //panel.transform.SetParent(content, false);
  }

  private void clearChildren()
  {
    foreach (Transform child in content)
    {
      GameObject.Destroy(child.gameObject);
    }
  }
}
