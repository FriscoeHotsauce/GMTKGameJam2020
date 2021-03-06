﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Phase
{
  Preparation, One, Two, Three, Intermission, End
}

public class PhaseManager : MonoBehaviour
{

  public float phaseOneInterval = 5.0f;
  public float phaseTwoInterval = 3.5f;
  public float phaseThreeInterval = 2.8f;

  public float phaseOneLength = 120.0f;
  public float phaseTwoLength = 180.0f;
  public float phaseThreeLength = 240.0f;

  public float phaseCooldownLength = 10.0f;
  public float nextPhaseBeginsAt;
  public float phaseEndsAt;
  public float nextTaskAt;

  public Phase currentPhase;
  public Phase nextPhase;

  public Text currentPhaseText;
  public Text timeRemainingText;

  public GameObject playAgainButton;

  private SequenceManager sequenceManager;
  private ShopManager shopManager;

  // Start is called before the first frame update
  void Start()
  {
    sequenceManager = GameObject.FindGameObjectWithTag("SequenceManager").GetComponent<SequenceManager>();
    shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();
    currentPhase = Phase.Preparation;
    nextPhase = Phase.One;
    nextPhaseBeginsAt = 0.0f;
    phaseEndsAt = 0.0f;
  }

  // Update is called once per frame
  void Update()
  {
    evaluatePhaseChange();
    evaluateTasks();
    updatePhaseText();
  }

  private void evaluateTasks()
  {
    if (nextTaskAt < Time.time && currentPhase != Phase.Intermission && currentPhase != Phase.End)
    {
      nextTaskAt = Time.time + spawnTaskAndGetPhaseInterval();
    }
  }

  private float spawnTaskAndGetPhaseInterval()
  {
    if (currentPhase == Phase.One)
    {
      sequenceManager.generateNewTask(currentPhase);
      return phaseOneInterval;
    }
    else if (currentPhase == Phase.Two)
    {
      sequenceManager.generateNewTask(currentPhase);
      return phaseTwoInterval;
    }
    else if (currentPhase == Phase.Three)
    {
      sequenceManager.generateNewTask(currentPhase);
      return phaseThreeInterval;
    }
    return 0.0f;
  }

  private void evaluatePhaseChange()
  {
    //the preparation phase ends when the current list of tasks has been completed
    if (Phase.Preparation == currentPhase)
    {
      evaluatePreperationOver();
    }
    else if (Phase.Intermission == currentPhase)
    {
      evaluateIntermissionOver();
    }
    else
    {
      evaluatePhaseEnd();
    }
  }

  private void evaluatePreperationOver()
  {
    if (sequenceManager.getTasksRemaining() == 0)
    {
      setIntermission();
    }
  }

  private void evaluateIntermissionOver()
  {
    if (nextPhaseBeginsAt < Time.time)
    {
      currentPhase = nextPhase;
      nextPhase = getNextPhase();
      shopManager.resumePurchases();
    }
  }

  private void evaluatePhaseEnd()
  {
    if (phaseEndsAt < Time.time)
    {
      if (currentPhase == Phase.Three)
      {
        currentPhase = Phase.End;
        enablePlayAgainButton();
      }
      else
      {
        currentPhase = Phase.Intermission;
        setIntermission();
      }
    }
  }

  private void setIntermission()
  {
    currentPhase = Phase.Intermission;
    nextPhaseBeginsAt = Time.time + phaseCooldownLength;
    sequenceManager.clearAllTasks();
    shopManager.pausePurchases();
  }

  private Phase getNextPhase()
  {
    if (Phase.One == currentPhase)
    {
      nextTaskAt = Time.time + phaseOneInterval;
      phaseEndsAt = Time.time + phaseOneLength;
      return Phase.Two;
    }
    else if (Phase.Two == currentPhase)
    {
      nextTaskAt = Time.time + phaseTwoInterval;
      phaseEndsAt = Time.time + phaseTwoLength;
      return Phase.Three;
    }
    else
    {
      nextTaskAt = Time.time + phaseThreeInterval;
      phaseEndsAt = Time.time + phaseThreeLength;
      return Phase.End;
    }
  }

  private void updatePhaseText()
  {
    currentPhaseText.text = currentPhase.ToString();
    if (currentPhase == Phase.Preparation || currentPhase == Phase.End)
    {
      timeRemainingText.text = "- - : - -";
    }
    else if (currentPhase == Phase.Intermission)
    {
      timeRemainingText.text = (String.Format("{0:.00}", Math.Round(nextPhaseBeginsAt - Time.time, 2)));
    }
    else
    {
      timeRemainingText.text = (String.Format("{0:.00}", Math.Round(phaseEndsAt - Time.time, 2)));
    }

  }

  public void enablePlayAgainButton()
  {
    playAgainButton.SetActive(true);
  }

  public void resetAndPlayAgain()
  {
    currentPhase = Phase.Preparation;
    nextPhase = Phase.One;
    sequenceManager.clearAllTasks();
    sequenceManager.setStartingTasks();
    shopManager.clearAllItemsFromShop();
    shopManager.resetCustomers();
    shopManager.resetGold();
    shopManager.pausePurchases();
    playAgainButton.SetActive(false);
  }
}
