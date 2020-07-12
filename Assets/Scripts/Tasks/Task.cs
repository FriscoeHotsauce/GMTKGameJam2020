using System.Collections.Generic;

public interface Task
{
  bool evaluate(List<ButtonHistory> buttonHistory, float time);
  int score();
  float timeGenerated();
}
