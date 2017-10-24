using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour{
	
public AudioClip hatch;
private AudioSource audioSource;
	 
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}
		
	void Update(){
							if (Input.GetMouseButtonDown(0))
							Debug.Log("Pressed left click.");
							if (Input.GetMouseButtonDown(1))
							Debug.Log("Pressed right click.");

			if (Input.GetMouseButtonDown (0)) {
				//	Application.Quit ();
				Debug.Log ("Quit");
			}
			if (Input.GetMouseButtonDown (1)) {
				//move to MainGame	
				audioSource.clip = hatch;
				audioSource.Play ();
				SceneManager.LoadScene ("MainGame");
			}
	}
}	