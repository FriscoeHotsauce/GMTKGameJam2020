using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAwayOnDestroy : MonoBehaviour
{
  public Animator animator;

  void Start()
  {
    animator = transform.GetComponent<Animator>();
  }

  // Start is called before the first frame update
  void OnDestroy()
  {
    animator.Play("TaskPanelFlyAway");
  }
}
