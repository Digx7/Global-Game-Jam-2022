using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private int p1Score;
    [SerializeField] private int p2Score;
    [SerializeField] private int maxScore;

    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;

    public UnityEvent GameStart_Event;
    public UnityEvent GameEnd_Event;
    public UnityEvent P1won_Event;
    public UnityEvent P2won_Event;
    public Animator GameManager_Animator;

    private Character_Action_Manager P1_Action_Manager;
    private Character_Action_Manager P2_Action_Manager;

    private Health_Manager P1_Health_Manager;
    private Health_Manager P2_Health_Manager;

    private Bullet_Detector P1_Bullet_Detector;
    private Bullet_Detector P2_Bullet_Detector;

    private Animation_Manager P1_Animation_Manager;
    private Animation_Manager P2_Animation_Manager;

    public void Awake (){
      //Set up all private variables

      if(p1 != null){
        P1_Action_Manager = p1.GetComponentInChildren<Character_Action_Manager>();
        P1_Health_Manager = p1.GetComponentInChildren<Health_Manager>();
        P1_Bullet_Detector = p1.GetComponentInChildren<Bullet_Detector>();
        P1_Animation_Manager = p1.GetComponentInChildren<Animation_Manager>();
      }

      if(p2 != null){
        P2_Action_Manager = p2.GetComponentInChildren<Character_Action_Manager>();
        P2_Health_Manager = p2.GetComponentInChildren<Health_Manager>();
        P2_Bullet_Detector = p2.GetComponentInChildren<Bullet_Detector>();
        P2_Animation_Manager = p2.GetComponentInChildren<Animation_Manager>();
      }
    }

    public void Start (){
      GameStart();
    }

    public void GameStart (){
      GameStart_Event.Invoke();

      P1_Animation_Manager.PreGameAnimation();
      P2_Animation_Manager.PreGameAnimation();
    }

    public void GameEnd (){
      GameEnd_Event.Invoke();

      GameManager_Animator.SetTrigger("GameEnd");
      if(P1won()) P1won_Event.Invoke();
      if(P2won()) P2won_Event.Invoke();
    }

    public void PlayVictoryAnimation(){
      if(p1Score > p2Score){
        // P1 won
        P1_Animation_Manager.WonAnimation();
        P2_Animation_Manager.LostAnimation();
      }
      else {
        // P2 won
        P1_Animation_Manager.LostAnimation();
        P2_Animation_Manager.WonAnimation();
      }
    }

    public void startNewRound (){
      GameManager_Animator.SetTrigger("RoundStart");
    }

    public void startRound (){

      setPlayerLocks(false);
      setPlayersCanDoStuff(true);
    }

    public void endRound (string input){
      //Clean up stuff after round
      Debug.Log("Round has ended");

      setPlayersCanDoStuff(false);

      if(input == "Player 1"){
        p2Score++;
      }

      if(input == "Player 2"){
        p1Score++;
      }

      // Ending round flare

      if(!maxScoreReached()) startNewRound();
      else GameEnd();
    }

    public void setPlayerLocks (bool input){
      P1_Action_Manager.LOCK_CANSELECTACTION(input);
      P2_Action_Manager.LOCK_CANSELECTACTION(input);
    }

    public void setPlayersCanDoStuff (bool input){
      P1_Action_Manager.Set_CanSelectAcion(input);
      P1_Health_Manager.setIsAlive(input);
      P1_Bullet_Detector.Set_CanTakeDamage(input);

      P2_Action_Manager.Set_CanSelectAcion(input);
      P2_Health_Manager.setIsAlive(input);
      P2_Bullet_Detector.Set_CanTakeDamage(input);
    }

    private bool maxScoreReached (){
      if(p1Score >= maxScore) return true;
      if(p2Score >= maxScore) return true;
      return false;
    }

    private string whoWon (){
      if(p1Score >= maxScore) return "Player 1";
      if(p2Score >= maxScore) return "Player 1";
      return "Null";
    }

    private bool P1won(){
      if(p1Score > p2Score) return true;
      else return false;
    }

    private bool P2won(){
      if(p1Score < p2Score) return true;
      else return false;
    }
}
