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
    int taskType = rando.Next(100);

    //40% chance to generate a single button task
    if (taskType < 40)
    {
      return generateSingleTask(time);
    }
    //45% chance to generate a two button task
    else if (taskType >= 40 && taskType < 85)
    {
      return generateSequencedTask(time, 2);
    }
    //15% chance to generate a slider task
    else
    {
      return generateSliderTask(time);
    }
  }

  public Task generatePhaseTwoTask(float time)
  {

    int taskType = rando.Next(100);

    //20% chance to generate a single task
    if (taskType < 20)
    {
      return generateSingleTask(time);
    }
    //40% chance to generate a two sequence task
    else if (taskType >= 20 && taskType < 60)
    {
      return generateSequencedTask(time, 2);
    }
    //25% chance to generate a three sequence task
    else if (taskType >= 60 && taskType < 85)
    {
      return generateSequencedTask(time, 3);
    }
    //15% chance to generate a slider task
    else
    {
      return generateSliderTask(time);
    }
  }

  public Task generatePhaseThreeTask(float time)
  {

    int taskType = rando.Next(100);

    //25% chance to generate a two sequence task
    if (taskType < 25)
    {
      return generateSequencedTask(time, 2);
    }
    //35% chance to generate a three sequence task
    else if (taskType >= 25 && taskType < 65)
    {
      return generateSequencedTask(time, 3);
    }
    //20% chance to generate a four sequence task
    else if (taskType >= 65 && taskType < 85)
    {
      return generateSequencedTask(time, 4);
    }
    //15% chance to generate a slider task
    else
    {
      return generateSliderTask(time);
    }
  }


  private Task generateSingleTask(float time)
  {
    return new SingleTask((ButtonPressed)rando.Next(7), time);
  }

  private Task generateSequencedTask(float time, int sequenceLength)
  {
    List<ButtonPressed> sequence = new List<ButtonPressed>();
    for (int i = 0; i < sequenceLength; i++)
    {
      sequence.Add((ButtonPressed)rando.Next(7));
    }
    return new ButtonSequenceTask(sequence, time);
  }

  private Task generateSliderTask(float time)
  {
    int sliderColor = rando.Next(3);
    return new SliderTask((ButtonPressed)(8 + sliderColor), (Slider)sliderColor, rando.Next(10), time);
  }
}
