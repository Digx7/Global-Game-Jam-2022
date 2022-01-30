using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bluff_Action : MonoBehaviour
{

    public UnityEvent Bluff_Action_Event;

    public void Bluff(Action input){
      if(input == Action.bluff) Bluff();
    }

    public void Bluff () {
      Debug.Log("Bluff Action");
      //Needs to play bluff animation
      Bluff_Action_Event.Invoke();
    }
}
