﻿using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float speed = 10.0f;
	private float shootTimer = 0, fireRate = .2f;

	public int score = 0, lives = 3;
	public AudioClip gunShot;
	public AudioClip DamageTaken;
	private AudioSource source;

	void Awake()
	{
			source = GetComponent<AudioSource>();
		
	}
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
		/*
		//IF we do want to add movement

		float translation = Input.GetAxis("Vertical") * speed;
		float straffe = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate(0, 0, translation);
		//*/

		if(Input.GetKeyDown("escape"))
			Cursor.lockState = CursorLockMode.None;
		
		shootTimer += Time.deltaTime;
		if(Input.GetButtonDown("Fire1") && shootTimer > fireRate)
			Shoot();


		Debug.DrawRay(transform.position, transform.forward);
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 1000)){
			if(hit.collider.tag == "Alien"){
				hit.collider.GetComponent<AlienBehavior>().Detected();
			}
		}

		if(lives <= 0){
			Die();
		}
	}

	void Die(){
		//Ohnoes he dieded, implement stuff
	}
	void Shoot(){
		source.PlayOneShot(gunShot, .5f);
		shootTimer = 0;
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100))
			if(hit.collider.tag == "Alien"){
				Shot(hit.collider.gameObject);				
			}
	}


	public void Hit(){
		lives--;
		source.PlayOneShot(DamageTaken);
	}

	void Shot(GameObject alien){
		alien.GetComponent<AlienBehavior>().Die();
		score++;
	}
}
