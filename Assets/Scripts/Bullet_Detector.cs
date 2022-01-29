using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet_Detector : MonoBehaviour
{
    [SerializeField] private bool canTakeDamage = true;
    [SerializeField] private BoxCollider hurtBox;

    [TagSelector]
    public string tagToWatchFor;

    public UnityEvent tookDamage;

    public void Set_CanTakeDamage (bool input){
      canTakeDamage = input;
    }

    public void Toggle_CanTakeDamage (){
      canTakeDamage = !canTakeDamage;
    }

    public bool Get_CanTakeDamage (){
      return canTakeDamage;
    }

    public void GotShot (){
      if(Get_CanTakeDamage()) tookDamage.Invoke();
    }

    public void OnCollisionEnter (Collision col){
      if(col.gameObject.tag == tagToWatchFor) GotShot();
    }

    public void OnTriggerEnter (Collider col){
      if(col.gameObject.tag == tagToWatchFor) GotShot();
    }

}
