using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
  Manages input. I would rename it, but it's not worth the hastle during a game jam
*/
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

  void Update()
  {
    getInput();
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
