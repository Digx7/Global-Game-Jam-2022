using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private InputActions_Object InputActions_Object;
    private Character_Action_Manager P1_Action_Manager;
    private Character_Action_Manager P2_Action_Manager;

    public void Awake (){
      // set up this with both players Character_Action_Manager

      BindInputActions_Object();
    }

    private void BindInputActions_Object (){
      InputActions_Object = new InputActions_Object();

      if(player1 != null){
        // bind p1 inputs

        P1_Action_Manager = player1.GetComponentInChildren<Character_Action_Manager>();

        InputActions_Object.Game.P1_Shoot.performed += ctx => this.P1_Shoot();
        InputActions_Object.Game.P1_Bluff.performed += ctx => this.P1_Bluff();
        InputActions_Object.Game.P1_Dodge.performed += ctx => this.P1_Dodge();
      }

      if(player2 != null){
        // bind p2 inputs

        P2_Action_Manager = player2.GetComponentInChildren<Character_Action_Manager>();

        InputActions_Object.Game.P2_Shoot.performed += ctx => this.P2_Shoot();
        InputActions_Object.Game.P2_Bluff.performed += ctx => this.P2_Bluff();
        InputActions_Object.Game.P2_Dodge.performed += ctx => this.P2_Dodge();
      }
    }

    private void OnEnable(){
      InputActions_Object.Enable();
    }

    private void OnDisable(){
      InputActions_Object.Disable();
    }

    public void P1_Shoot (){
      Action choice = Action.shoot;
      P1_Action_Manager.Set_SelectedAction(choice);
      P1_Action_Manager.PlaySelectedAction();
    }
    public void P1_Bluff (){
      Action choice = Action.bluff;
      P1_Action_Manager.Set_SelectedAction(choice);
      P1_Action_Manager.PlaySelectedAction();
    }
    public void P1_Dodge (){
      Action choice = Action.dodge;
      P1_Action_Manager.Set_SelectedAction(choice);
      P1_Action_Manager.PlaySelectedAction();
    }

    public void P2_Shoot (){
      Action choice = Action.shoot;
      P2_Action_Manager.Set_SelectedAction(choice);
      P2_Action_Manager.PlaySelectedAction();
    }
    public void P2_Bluff (){
      Action choice = Action.bluff;
      P2_Action_Manager.Set_SelectedAction(choice);
      P2_Action_Manager.PlaySelectedAction();
    }
    public void P2_Dodge (){
      Action choice = Action.dodge;
      P2_Action_Manager.Set_SelectedAction(choice);
      P2_Action_Manager.PlaySelectedAction();
    }
}
