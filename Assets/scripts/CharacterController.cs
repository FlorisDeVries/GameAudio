using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float speed = 10.0f;
	private float shootTimer = 0, fireRate = .2f;

	public int lives = 3;
	private bool dead = false;
	public AudioClip gunShot;
	public AudioClip damageTaken;
	public AudioClip gameOver;
	public AudioClip detectedAlien;
	private AudioSource source;

	public GameController controller;

	private float timer = 0;
	private bool playAudio = true;

	void Awake()
	{
			source = GetComponent<AudioSource>();
		
	}
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
		if(dead)
			return;
		if(Input.GetKeyDown("escape"))
			Cursor.lockState = CursorLockMode.None;
		
		shootTimer += Time.deltaTime;
		if(Input.GetButtonDown("Fire1") && shootTimer > fireRate)
			Shoot();


		timer += Time.deltaTime;
		if(timer > detectedAlien.length)
			playAudio = true;

		CheckLockOn();

		if(lives <= 0){
			dead=true;
			controller.GameOver();
		}
	}

	void CheckLockOn(){
		Debug.DrawRay(transform.position, transform.forward);
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 1000)){
			if(hit.collider.tag == "Alien"){
				bool spawned = hit.collider.GetComponent<AlienBehavior>().spawned;
				bool alive = hit.collider.GetComponent<AlienBehavior>().alive;
				if(spawned && playAudio && alive){
					source.PlayOneShot(detectedAlien);
					timer = 0;
					playAudio = false;
				}
			}
		}
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
		source.PlayOneShot(damageTaken);
	}

	void Shot(GameObject alien){
		alien.GetComponent<AlienBehavior>().Die(true);
	}
}
