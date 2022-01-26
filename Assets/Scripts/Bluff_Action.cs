using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluff_Action : MonoBehaviour
{

    public void Bluff(Action input){
      if(input == Action.bluff) Bluff();
    }

    public void Bluff () {
      Debug.Log("Bluff Action");
      //Needs to play bluff animation
    }
}
