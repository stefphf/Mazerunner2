﻿using UnityEngine;
using System.Collections;

public class aiEasy : MonoBehaviour {

	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public Transform fpsTarget;
	Rigidbody theRigidbody;
	Renderer myRender;

	// Use this for initialization
	void Start () {
		myRender = GetComponent<Renderer>();
		theRigidbody = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		fpsTargetDistance = Vector3.Distance(fpsTarget.position,transform.position);
		if (fpsTargetDistance<enemyLookDistance){
			myRender.material.color=Color.yellow;
			lookAtPlayer ();
			print ("Посмотри пожалуйста на игрока");
		}
		if (fpsTargetDistance < attackDistance) {
			myRender.material.color = Color.red;
			
			attackPlease ();
			print ("АТАКА!");
		} else {
			myRender.material.color = Color.blue;
		}
	}
	
	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*damping);
		
	}

	void attackPlease(){
		theRigidbody.AddForce(transform.forward*enemyMovementSpeed);
	}

}
