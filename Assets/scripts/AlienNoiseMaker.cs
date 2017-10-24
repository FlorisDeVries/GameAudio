using UnityEngine;
using System.Collections;

public class AlienNoiseMaker : MonoBehaviour {

	public AudioClip noise1, noise2, noise3;

	private AudioClip clip;


	private AudioSource source;

	private float timer;

	void Awake()
	{
		source = GetComponent<AudioSource>();	
	}

	void Start () {
		RandomClip();
		timer = clip.length;
	}
	
	// Update is called once per frame
	void Update () {
		if(!transform.parent.gameObject.GetComponent<AlienBehavior>().spawned)
			return;

		if(!transform.parent.gameObject.GetComponent<AlienBehavior>().alive){
			source.Stop();
			return;
		}
		
		timer += Time.deltaTime;
		if(timer > clip.length){
			source.PlayOneShot(clip, 3f);
			RandomClip();
			timer = 0;
		}
	}

	void RandomClip(){
		AudioClip[] clips = new AudioClip[3] {noise1, noise2, noise3};
		clip = clips[Random.Range(0,3)];
	}
}
