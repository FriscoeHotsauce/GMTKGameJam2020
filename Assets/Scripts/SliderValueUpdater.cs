using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderValueUpdater : MonoBehaviour
{
  public Text powerText;

  void Start()
  {
    powerText = transform.GetComponent<Text>();
  }

  public void updateText(System.Single val)
  {
    powerText.text = val.ToString();
  }
}
