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
	private AudioSource source;

	public GameController controller;

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


		Debug.DrawRay(transform.position, transform.forward);
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 1000)){
			if(hit.collider.tag == "Alien"){
				hit.collider.GetComponent<AlienBehavior>().Detected();
			}
		}

		if(lives <= 0){
			dead=true;
			controller.GameOver();
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
