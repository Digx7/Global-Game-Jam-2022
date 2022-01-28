using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health_Manager : MonoBehaviour
{
    [SerializeField] bool isAlive = true;

    public UnityEvent hasDied;
    public UnityEvent hasRevived;

    public void Kill (){
      if(isAlive) {
        setIsAlive(false);
        hasDied.Invoke();
      }
    }

    public void Revive (){
      if(!isAlive) {
        setIsAlive(true);
        hasRevived.Invoke();
      }
    }

    public void setIsAlive (bool input){
      isAlive = input;
    }

    public void toggleIsAlive (){
      isAlive = !isAlive;
    }
}
