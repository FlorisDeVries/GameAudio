using UnityEngine;
using UnityEngine.SceneManagement;


public class RightClickLoadGame : MonoBehaviour 
{

	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("Pressed right click."); 
			SceneManager.LoadScene ("MainGame");
		}
	}
}