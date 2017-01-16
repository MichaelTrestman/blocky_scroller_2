using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track_pc : MonoBehaviour {
	public float maxZoom = 100f;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");

	}


	void Update () {


		if (player == null){
			return;
		}
		if (player.GetComponent<pc>().IsTeleporting()){
			return;
		}

		var oldPos = transform.position;
		var newPos = new Vector3( player.transform.position.x, player.transform.position.y, -10 );
		transform.position = newPos;





		if ( Input.GetKeyUp(KeyCode.E) && ( gameObject.GetComponent<Camera>().orthographicSize <= maxZoom ) ){			
			gameObject.GetComponent<Camera>().orthographicSize *= 1.7f;
		} else if (Input.GetKeyUp(KeyCode.R)){
			gameObject.GetComponent<Camera>().orthographicSize *= (1f/1.7f);
		}	
			
		if (Input.GetKeyUp(KeyCode.P)){
			Time.timeScale = 0.0001f;
			gameObject.GetComponent<Camera> ().orthographicSize *= 2;

		} else if (Input.GetKeyUp(KeyCode.Y)){
			Time.timeScale = 1f;
			gameObject.GetComponent<Camera> ().orthographicSize = maxZoom;
		}
	}
}
