using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Prefab : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector3 bulletTrajectory;
    [SerializeField] private Rigidbody bulletRigidBody;

    public void Start (){
      if (bulletSpeed == 0.0f) bulletSpeed = 1000.0f;
      if (bulletTrajectory == Vector3.zero) bulletTrajectory = Vector3.right;
      if (bulletRigidBody == null) bulletRigidBody = this.GetComponent<Rigidbody>();
    }

    public void FixedUpdate (){
      bulletRigidBody.velocity = bulletTrajectory * bulletSpeed * Time.deltaTime;
    }
}
