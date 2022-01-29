using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health_Manager : MonoBehaviour
{
    [SerializeField] private bool isAlive = true;

    [TagSelector] public string Obj_Name;
    public StringEvent hasDied;
    public UnityEvent hasRevived;

    public void Kill (){
      if(isAlive) {
        setIsAlive(false);
        hasDied.Invoke(Obj_Name);
        Debug.Log("I died");
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
