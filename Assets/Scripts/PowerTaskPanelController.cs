using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerTaskPanelController : MonoBehaviour
{

  public Text powerLevel;
  public Image colorIndicator;
  public Image powerButton;

  public Color purple;
  public Color blue;
  public Color orange;
  public Color green;

  public Sprite purplePower;
  public Sprite bluePower;
  public Sprite orangePower;
  public Sprite greenPower;

  public void setPanel(Slider slider, int powerLevel)
  {
    this.powerLevel.text = powerLevel.ToString();
    colorIndicator.color = getColorForSlider(slider);
    powerButton.sprite = getSpriteForSlider(slider);
  }

  private Sprite getSpriteForSlider(Slider slider)
  {
    if (slider == Slider.purpleSlider)
    {
      return purplePower;
    }
    else if (slider == Slider.blueSlider)
    {
      return bluePower;
    }
    else if (slider == Slider.orangeSlider)
    {
      return orangePower;
    }
    else if (slider == Slider.greenSlider)
    {
      return greenPower;
    }
    return null;
  }

  private Color getColorForSlider(Slider slider)
  {
    if (slider == Slider.purpleSlider)
    {
      return purple;
    }
    else if (slider == Slider.blueSlider)
    {
      return blue;
    }
    else if (slider == Slider.orangeSlider)
    {
      return orange;
    }
    else
    {
      return green;
    }
  }
}
