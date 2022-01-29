using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Prefab : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector3 bulletTrajectory;
    [SerializeField] private Rigidbody bulletRigidBody;

    public void Start (){
      if (bulletSpeed == 0.0f) bulletSpeed = 100.0f;
      if (bulletTrajectory == Vector3.zero) bulletTrajectory = Vector3.up;
      if (bulletRigidBody == null) bulletRigidBody = this.GetComponent<Rigidbody>();
    }

    public void FixedUpdate (){
      Vector3 forwardVel = transform.forward * bulletSpeed * bulletTrajectory.x;
      Vector3 horizontalVel = transform.right * bulletSpeed * bulletTrajectory.y;

      bulletRigidBody.velocity = forwardVel + horizontalVel;
    }
}
