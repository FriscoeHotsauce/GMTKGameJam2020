using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTask : Task
{
  public ButtonPressed buttonToPress;
  public Slider sliderToModify;
  public int expectedPowerLevel;
  public float createdAt;

  public SliderTask(ButtonPressed buttonToPress, Slider sliderToModify, int expectedPowerLevel, float createdAt)
  {
    this.buttonToPress = buttonToPress;
    this.expectedPowerLevel = expectedPowerLevel;
    this.createdAt = createdAt;
    this.sliderToModify = sliderToModify;
  }

  public bool evaluate(List<ButtonHistory> buttonHistory, float time)
  {
    // return (buttonHistory[0].getButtonPressed() == buttonToPress && buttonHistory[0].getTime() > createdAt && powerLevelCorrect());
    return (powerLevelCorrect());
  }

  public int score()
  {
    return 2;
  }

  public float timeGenerated()
  {
    return createdAt;
  }

  public ButtonPressed getButtonToPress()
  {
    return buttonToPress;
  }

  public Slider getSliderToModify()
  {
    return sliderToModify;
  }

  public int getExpectedPowerLevel()
  {
    return expectedPowerLevel;
  }

  private bool powerLevelCorrect()
  {
    if (buttonToPress == ButtonPressed.purplePower)
    {
      return GameObject.FindGameObjectWithTag("PurpleSlider").GetComponent<UnityEngine.UI.Slider>().value == expectedPowerLevel;
    }
    else if (buttonToPress == ButtonPressed.bluePower)
    {
      return GameObject.FindGameObjectWithTag("BlueSlider").GetComponent<UnityEngine.UI.Slider>().value == expectedPowerLevel;
    }
    else if (buttonToPress == ButtonPressed.orangePower)
    {
      return GameObject.FindGameObjectWithTag("OrangeSlider").GetComponent<UnityEngine.UI.Slider>().value == expectedPowerLevel;
    }
    else if (buttonToPress == ButtonPressed.greenPower)
    {
      return GameObject.FindGameObjectWithTag("GreenSlider").GetComponent<UnityEngine.UI.Slider>().value == expectedPowerLevel;
    }
    return false;
  }

}
