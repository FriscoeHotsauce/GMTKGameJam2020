using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDriver : MonoBehaviour
{
  public Button purpleCircleButton;
  public Button blueCircleButton;
  public Button orangeCircleButton;
  public Button greenCircleButton;

  public Button purpleSquareButton;
  public Button blueSquareButton;
  public Button orangeSquareButton;
  public Button greenSquareButton;

  public Slider purpleSlider;
  public Slider blueSlider;
  public Slider orangeSlider;
  public Slider greenSlider;

  public Toggle purpleToggle;
  public Toggle blueToggle;
  public Toggle orangeToggle;
  public Toggle greenToggle;

  public float newTaskInterval = 3.0f;
  public float currentTime;
  public SequenceManager sequenceManager;
  public bool requiresValidationPass;

  void Start()
  {
    currentTime = 0.0f;
    sequenceManager = GameObject.FindGameObjectWithTag("SequenceManager").GetComponent<SequenceManager>();
    requiresValidationPass = false;
  }

  void Update()
  {
    getInput();
    currentTime += Time.deltaTime;
    if (currentTime > newTaskInterval)
    {
      //generate new task
      sequenceManager.generateNewTask();
      currentTime = 0.0f;
    }
    sequenceManager.evaluteAllTasks();
  }

  public void getInput()
  {
    if (Input.GetKeyDown("w"))
    {
      purpleCircleButton.onClick.Invoke();
    }
    if (Input.GetKeyDown("a"))
    {
      blueCircleButton.onClick.Invoke();
    }
    if (Input.GetKeyDown("s"))
    {
      orangeCircleButton.onClick.Invoke();
    }
    if (Input.GetKeyDown("d"))
    {
      greenCircleButton.onClick.Invoke();
    }

    if (Input.GetKeyDown("up"))
    {
      purpleSquareButton.onClick.Invoke();
    }
    if (Input.GetKeyDown("left"))
    {
      blueSquareButton.onClick.Invoke();
    }
    if (Input.GetKeyDown("down"))
    {
      orangeSquareButton.onClick.Invoke();
    }
    if (Input.GetKeyDown("right"))
    {
      greenSquareButton.onClick.Invoke();
    }
  }
}
