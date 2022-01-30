using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dodge_Action : MonoBehaviour
{

    public UnityEvent Dodge_Action_Event;

    [SerializeField] private Bullet_Detector Bullet_Detector;

    public void Dodge(Action input){
      if(input == Action.dodge) Dodge();
    }

    public void Dodge () {
      Debug.Log("Dodge Action");
      //needs to play dodge animation
      //needs to turn off health breifly

      Bullet_Detector.Set_CanTakeDamage(false); // needs to turn this back on after a bit
      Dodge_Action_Event.Invoke();
    }
}
