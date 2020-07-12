using System;
using System.Collections;
using System.Collections.Generic;

public class TaskGenerator
{
  Random rando;

  public TaskGenerator()
  {
    rando = new Random();
  }

  public List<Task> generateStartingTasks()
  {
    List<Task> startingTasks = new List<Task>();
    startingTasks.Add(new SingleTask(ButtonPressed.purpleCircle, 0.0f));
    startingTasks.Add(new SingleTask(ButtonPressed.blueCircle, 0.0f));
    startingTasks.Add(new SingleTask(ButtonPressed.orangeCircle, 0.0f));
    startingTasks.Add(new SingleTask(ButtonPressed.greenCircle, 0.0f));
    startingTasks.Add(new SingleTask(ButtonPressed.purpleSquare, 0.0f));
    startingTasks.Add(new SingleTask(ButtonPressed.blueSquare, 0.0f));
    startingTasks.Add(new SingleTask(ButtonPressed.orangeSquare, 0.0f));
    startingTasks.Add(new SingleTask(ButtonPressed.greenSquare, 0.0f));
    startingTasks.Add(new SliderTask(ButtonPressed.purplePower, Slider.purpleSlider, 5, 0.0f));
    startingTasks.Add(new SliderTask(ButtonPressed.bluePower, Slider.blueSlider, 5, 0.0f));
    startingTasks.Add(new SliderTask(ButtonPressed.orangePower, Slider.orangeSlider, 5, 0.0f));
    startingTasks.Add(new SliderTask(ButtonPressed.greenPower, Slider.greenSlider, 5, 0.0f));

    return startingTasks;
  }

  public Task generatePhaseOneTask(float time)
  {
    int taskType = rando.Next(10);

    if (taskType <= 4)
    {
      return new SingleTask((ButtonPressed)rando.Next(7), time);
    }
    else if (taskType > 4 && taskType <= 8)
    {
      List<ButtonPressed> sequence = new List<ButtonPressed>();
      for (int i = 0; i < 2; i++)
      {
        sequence.Add((ButtonPressed)rando.Next(8));
      }
      return new ButtonSequenceTask(sequence, time);
    }
    else
    {
      int sliderColor = rando.Next(3);
      return new SliderTask((ButtonPressed)(8 + sliderColor), (Slider)sliderColor, rando.Next(10), time);
    }
  }

}
