using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPC : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;
	public float moveRate = 5;
	public float personalSpace = 10;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.FindWithTag("Player");

		InvokeRepeating ("moveTowardPlayer", 0.5f, 0.2f);
	}

	void moveTowardPlayer (){
		var vel = rb.velocity;	

		var xDiff = (player.transform.position.x - gameObject.transform.position.x)*(player.transform.position.x - gameObject.transform.position.x);

		if (player.transform.position.x > gameObject.transform.position.x) {
			if ( xDiff > personalSpace  ) {
				vel.x += moveRate;		
			}
		} else if (player.transform.position.x < gameObject.transform.position.x) {
			if (xDiff > personalSpace) {
				vel.x -= moveRate;		
			}
		}
		rb.velocity = vel;

	}

}
