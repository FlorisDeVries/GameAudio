using UnityEngine;
using System.Collections;

public class AlienNoiseMaker : MonoBehaviour {

	public AudioClip noise;

	private AudioSource source;

	private float timer;

	void Awake()
	{
		source = GetComponent<AudioSource>();	
	}

	void Start () {
		timer = noise.length;
	}
	
	// Update is called once per frame
	void Update () {
		if(!transform.parent.gameObject.GetComponent<AlienBehavior>().alive){
			source.Stop();
			return;
		}
		
		timer += Time.deltaTime;
		if(timer > noise.length){
			source.PlayOneShot(noise, 3f);
			timer = 0;
		}
	}
}
