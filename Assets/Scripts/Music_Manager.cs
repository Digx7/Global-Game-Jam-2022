using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Manager : MonoBehaviour
{
  private static Music_Manager _instance;

  public static Music_Manager Instance { get { return _instance; } }

  [SerializeField] private List<Music_Cue> CueList;
  [SerializeField] private AudioSource audioSource;
  [SerializeField] private Animator animator;

  private AudioClip nextClip;

  private void Awake()
  {
      if (_instance != null && _instance != this)
      {
          Destroy(this.gameObject);
      } else {
          _instance = this;
      }

      SceneManager.activeSceneChanged += CheckIfShouldChangeQue;
      DontDestroyOnLoad(this);
  }

  private void CheckIfShouldChangeQue (Scene current, Scene next){
    for(int i=0; i < CueList.Count; ++i){
      if(CueList[i].sceneToCueIn == next.name) ChangeCue(i);
    }
  }

  public void ChangeCue (){
    audioSource.clip = nextClip;
  }

  public void Play (){
    audioSource.Play();
  }

  private void ChangeCue (int index){
    nextClip = CueList[index].song;
    animator.SetTrigger("Transition");
  }

}
