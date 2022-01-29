using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Action : MonoBehaviour
{

    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private Transform bulletSpawningPoint;


    public void Shoot(Action input){
      if(input == Action.shoot) Shoot();
    }

    public void Shoot () {
      Debug.Log("Shoot Action");
      Instantiate(bullet_prefab, bulletSpawningPoint.position, bulletSpawningPoint.rotation);
      //Needs to play shoot animation
    }
}
