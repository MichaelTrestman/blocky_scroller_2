using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
	bool facingRight;
	public GameObject sword;
	// Use this for initialization
	void Start () {
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.X)){
			SwordSwipe ();
		}
		if (Input.GetKey (KeyCode.D)) {
			facingRight = true;
		} else if (Input.GetKey(KeyCode.A)){
			facingRight = false;
		}

	}
	void SwordSwipe (){
		Instantiate (sword, gameObject.transform);
	}
}
