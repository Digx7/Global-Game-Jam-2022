using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Action : MonoBehaviour
{

    [SerializeField] private Bullet_Detector Bullet_Detector;

    public void Dodge(Action input){
      if(input == Action.dodge) Dodge();
    }

    public void Dodge () {
      Debug.Log("Dodge Action");
      //needs to play dodge animation
      //needs to turn off health breifly

      Bullet_Detector.Set_CanTakeDamage(false); // needs to turn this back on after a bit
    }
}
