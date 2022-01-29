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
    public Animator GameManager_Animator;

    private Character_Action_Manager P1_Action_Manager;
    private Character_Action_Manager P2_Action_Manager;

    private Health_Manager P1_Health_Manager;
    private Health_Manager P2_Health_Manager;

    private Bullet_Detector P1_Bullet_Detector;
    private Bullet_Detector P2_Bullet_Detector;

    public void Awake (){
      //Set up all private variables

      if(p1 != null){
        P1_Action_Manager = p1.GetComponentInChildren<Character_Action_Manager>();
        P1_Health_Manager = p1.GetComponentInChildren<Health_Manager>();
        P1_Bullet_Detector = p1.GetComponentInChildren<Bullet_Detector>();
      }

      if(p2 != null){
        P2_Action_Manager = p2.GetComponentInChildren<Character_Action_Manager>();
        P2_Health_Manager = p2.GetComponentInChildren<Health_Manager>();
        P2_Bullet_Detector = p2.GetComponentInChildren<Bullet_Detector>();
      }
    }

    public void Start (){
      GameStart();
    }

    public void GameStart (){
      GameStart_Event.Invoke();
    }

    public void GameEnd (){
      GameEnd_Event.Invoke();
    }

    public void startRound (){
      //Set up stuff for a new round

      //Start Countdown
      Debug.Log("Countdown goes here");

      GameManager_Animator.SetTrigger("RoundStart");
      //setPlayersCanDoStuff(true);
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

      if(!maxScoreReached()) startRound();
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
}
