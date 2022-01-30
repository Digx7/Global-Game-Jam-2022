using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Score_Updater : MonoBehaviour
{
  [SerializeField] private Game_Manager game_Manager;
  [SerializeField] private TextMeshProUGUI p1_Score_Text;
  [SerializeField] private TextMeshProUGUI p2_Score_Text;

  public void UpdateUI (){
    p1_Score_Text.text = "" + game_Manager.Get_P1Score();
    p2_Score_Text.text = "" + game_Manager.Get_P2Score();
  }
}
