﻿using System.Collections.Generic;

public class MultiTask : Task
{

  private List<SingleTask> taskList;
  private float createdAt;
  private string id;

  public MultiTask(List<SingleTask> taskList, float createdAt)
  {
    this.taskList = taskList;
    this.createdAt = createdAt;
    this.id = System.Guid.NewGuid().ToString();
  }


  public bool evaluate(List<ButtonHistory> buttonHistory, float time)
  {
    foreach (Task item in taskList)
    {
      if (item.evaluate(buttonHistory, time))
      {
        continue;
      }
      else
      {
        return false;
      }
    }
    return true;
  }

  public int score()
  {
    int totalScore = 0;
    foreach (SingleTask task in taskList)
    {
      totalScore += task.score();
    }
    return totalScore;
  }

  public float timeGenerated()
  {
    return createdAt;
  }

  public string getId()
  {
    return id;
  }
}
