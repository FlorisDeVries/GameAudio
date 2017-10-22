using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject alienPrefab;

	private CharacterController playerController;
	public int maxAliens = 3;
	public int alienCount = 0;
	
	GameObject[] aliens;
	AlienBehavior[] alienBehavior;

	public AudioClip gameOver;
	private AudioSource source;

	private bool running = true ;

	public int score = 0;
	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<CharacterController>();
		source = GetComponent<AudioSource>();
		aliens = new GameObject[maxAliens];
		alienBehavior = new AlienBehavior[maxAliens];
	}
	
	// Update is called once per frame
	void Update () {
		if(!running)
			return;
		if(alienCount < maxAliens){
			SpawnAlien(alienCount);
			alienCount++;
		}
	}

	public void SpawnAlien(int index){
		Vector3 pos = RandomCircle(player.transform.position, 20);
		pos.y += 1;
		GameObject alien = (GameObject)Instantiate(alienPrefab, pos, transform.rotation);
		AlienBehavior alienBehavior = alien.GetComponent<AlienBehavior>();

		alienBehavior.player = player;
		alienBehavior.controller = this;
		alienBehavior.speed = 0.05f;
		alienBehavior.index = index;

		aliens[index] = alien;
		this.alienBehavior[index] = alienBehavior;

	}

	void PlayerHit(){
		playerController.Hit();
	}

	public void GameOver(){
		for(int i = 0; i < maxAliens; i++)
			Destroy(aliens[i]);
		source.PlayOneShot(gameOver);
		running = false;
	}

	Vector3 RandomCircle(Vector3 center, float distance){
		float ang = Random.Range(0, 360);
		Vector3 pos;
		pos.x = center.x + distance * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		pos.z = center.z + distance * Mathf.Cos(ang * Mathf.Deg2Rad);
		return pos;
	}

	public void AlienDying(int index, float length){
		Destroy(aliens[index], length);
		SpawnAlien(index);
	}
}
