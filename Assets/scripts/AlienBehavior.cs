using UnityEngine;
using System.Collections;

public class AlienBehavior : MonoBehaviour {

	public GameObject player;

	public AudioClip dyingAlien, detectedAlien;
	private AudioSource source;
	private bool playAudio = true, detected = false;
	public bool alive = true;
	private float timer;

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	void Start () {
	}

	public void Die(){
		alive = false;
		source.PlayOneShot(dyingAlien, 3f);
		var renderer = GetComponent<MeshRenderer>();
		renderer.enabled = false;
		Destroy(gameObject, dyingAlien.length);
	}

	public void Detected(){
		detected = true;
		if(playAudio){
			source.PlayOneShot(detectedAlien, 1f);
			timer = 0;
			playAudio = false;
		}
	}

	void Update () {
		if(!alive)
			return;

		if (!detected)
			source.Stop();
		timer += Time.deltaTime;
		if(timer > detectedAlien.length)
			playAudio = true;
		detected = false;
	}
}
