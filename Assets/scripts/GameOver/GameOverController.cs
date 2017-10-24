using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	private AudioSource source;

	public AudioClip instructions;
	float timer;

	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(timer==0)
			source.PlayOneShot(instructions);
		timer += Time.deltaTime;

		if(Input.GetButtonDown("Fire2"))
			Application.LoadLevel("MainGame");
	}
}
