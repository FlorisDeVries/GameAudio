
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class moveTowardsPlayer : MonoBehaviour {

	Transform tr_Player;
	float f_RotSpeed=3.0f,f_MoveSpeed = 0.5f;

	void Start () {

		tr_Player = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	void Update () {
		/* Look at Player*/
		transform.rotation = Quaternion.Slerp (transform.rotation
			, Quaternion.LookRotation (tr_Player.position - transform.position)
			, f_RotSpeed * Time.deltaTime);

		/* Move at Player*/
		transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
	}
		
	void OnCollisionEnter(){
		Application.LoadLevel(Application.loadedLevel);
		
		}
	}

