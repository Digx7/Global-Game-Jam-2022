using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character_Action_Manager : MonoBehaviour
{
    [SerializeField] private Action selectedAction;
    [SerializeField] private bool canSelectAction = false;
    [SerializeField] private bool lockSelectAction = false;

    public ActionEvent playSelectedActionEvent;

    // Getters and Setters --------------

    public void Set_SelectedAction (Action choice){
      if(canSelectAction) selectedAction = choice;
    }

    public Action Get_SelectedAction (){
      return selectedAction;
    }

    public void LOCK_CANSELECTACTION (bool input){
      lockSelectAction = input;
    }

    public void Set_CanSelectAcion (bool input){
      if(!lockSelectAction){
        canSelectAction = input;
        Debug.Log("Something set canSelectAction to " + input);
      }  
    }

    public bool Get_CanSelectAction (){
      return canSelectAction;
    }

    public void Toggle_CanSelectAction (){
      canSelectAction = !canSelectAction;
    }

    // Main Functions ---------------

    public void PlaySelectedAction (){
      if(Get_CanSelectAction()) playSelectedActionEvent.Invoke(selectedAction);
      Set_CanSelectAcion(false);
    }
}
