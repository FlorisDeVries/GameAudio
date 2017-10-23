using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	private AudioSource source;

	public AudioClip instructions, enteringGame;
	float timer;

	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(timer==0)
			source.PlayOneShot(instructions);
		timer += Time.deltaTime;

		if(Input.GetButtonDown("Fire2")){
			source.PlayOneShot(enteringGame);
			StartCoroutine("LoadMainGame");
		}
	}

	IEnumerator LoadMainGame(){
		yield return new WaitForSeconds(enteringGame.length);

		Application.LoadLevel("MainGame");
	}
}
