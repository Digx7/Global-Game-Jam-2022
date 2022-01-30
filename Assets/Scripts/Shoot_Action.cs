using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot_Action : MonoBehaviour
{

    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private Transform bulletSpawningPoint;

    public UnityEvent Shoot_Action_Event;


    public void Shoot(Action input){
      if(input == Action.shoot) Shoot();
    }

    public void Shoot () {
      Debug.Log("Shoot Action");
      Instantiate(bullet_prefab, bulletSpawningPoint.position, bulletSpawningPoint.rotation);
      Shoot_Action_Event.Invoke();
      //Needs to play shoot animation
    }
}
