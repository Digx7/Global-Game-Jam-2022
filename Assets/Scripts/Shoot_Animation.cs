using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot_Animation : StateMachineBehaviour
{

  public UnityEvent aRandomEvent;

  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
        aRandomEvent.Invoke();
        Debug.Log("A Random Event should have happened");
  }
}
