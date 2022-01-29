using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayActionAnimation (Action input){
      if(input == Action.shoot) ShootAnimation();
      else if(input == Action.dodge) DodgeAnimation();
      else if(input == Action.bluff) BluffAnimation();
    }

    public void ShootAnimation (){
      animator.SetTrigger("Shoot");
    }

    public void DodgeAnimation (){
      animator.SetTrigger("Dodge");
    }

    public void BluffAnimation (){
      animator.SetTrigger("Bluff");
    }
}
