using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanelController : MonoBehaviour
{
  public Text taskText;
  public Image firstImage;
  public Image secondImage;
  public Image thirdImage;
  public Image fourthImage;

  public Sprite purpleCircleSprite;
  public Sprite blueCircleSprite;
  public Sprite orangeCircleSprite;
  public Sprite greenCircleSprite;

  public Sprite purpleSquareSprite;
  public Sprite blueSquareSprite;
  public Sprite orangeSquareSprite;
  public Sprite greenSquareSprite;

  public void setButtons(List<ButtonPressed> sequence)
  {
    //the way the button sequence is rendered, they should be evaluated in the opposite order; instead of making the evaluation logic super conviluted, 
    // it was easier to just reverse the list when displaying the button prompts
    List<ButtonPressed> buttons = new List<ButtonPressed>(sequence);
    buttons.Reverse();
    if (buttons.Count >= 1)
    {
      setImage(firstImage, buttons[0]);
    }
    else
    {
      firstImage.enabled = false;
    }

    if (buttons.Count >= 2)
    {
      setImage(secondImage, buttons[1]);
    }
    else
    {
      secondImage.enabled = false;
    }

    if (buttons.Count >= 3)
    {
      setImage(thirdImage, buttons[2]);
    }
    else
    {
      thirdImage.enabled = false;
    }

    if (buttons.Count >= 4)
    {
      setImage(fourthImage, buttons[3]);
    }
    else
    {
      fourthImage.enabled = false;
    }
  }

  public void setImage(Image image, ButtonPressed button)
  {
    Sprite toSet = getSpriteForButton(button);
    image.sprite = toSet;
  }

  private Sprite getSpriteForButton(ButtonPressed button)
  {

    if (button == ButtonPressed.purpleCircle)
    {
      return purpleCircleSprite;
    }
    else if (button == ButtonPressed.blueCircle)
    {
      return blueCircleSprite;
    }
    else if (button == ButtonPressed.orangeCircle)
    {
      return orangeCircleSprite;
    }
    else if (button == ButtonPressed.greenCircle)
    {
      return greenCircleSprite;
    }
    else if (button == ButtonPressed.purpleSquare)
    {
      return purpleSquareSprite;
    }
    else if (button == ButtonPressed.blueSquare)
    {
      return blueSquareSprite;
    }
    else if (button == ButtonPressed.orangeSquare)
    {
      return orangeSquareSprite;
    }
    else if (button == ButtonPressed.greenSquare)
    {
      return greenSquareSprite;
    }

    return null;
  }


}
