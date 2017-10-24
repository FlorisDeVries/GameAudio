using UnityEngine;
using System.Collections;

public class AlienBehavior : MonoBehaviour {

	public GameObject player;
	public GameController controller;

	public AudioClip dyingAlien, detectedAlien, TPin;
	private AudioSource source;
	public bool alive = true, spawned = false;
	public float speed;
	private float timer= 0;
	public int index;

	

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	void Start () {
		transform.LookAt(player.transform);
		source.PlayOneShot(TPin);		
	}

	public void Die(bool scored){
		if(!alive || !spawned)
			return;

		alive = false;
		source.PlayOneShot(dyingAlien, 3f);
		var renderer = GetComponent<MeshRenderer>();
		renderer.enabled = false;

		controller.AlienDying(index, dyingAlien.length);
		if(scored)
			controller.score++;
	}


	void Update () {
		if(!spawned)
			if(timer < TPin.length){
				timer += Time.deltaTime;
				return;
			} else {
				spawned = true;
				timer = 0;
			}


		if(!alive)
			return;

		if(Vector3.Distance(transform.position, player.transform.position) < 2f){
			player.GetComponent<CharacterController>().Hit();
			Destroy(gameObject);
			controller.SpawnAlien(index);
		}
		transform.Translate(0, 0, speed);
	}
}
