using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAtRandomIntervals : MonoBehaviour {

	public float jumpHeight = 20f;
	public float jumpWaitFactor = 2f;

	void Start () {
		InvokeRepeating ("WaitRandomlyThenJump", 1f, jumpWaitFactor);
	}
	void WaitRandomlyThenJump(){
		float waitTime = Random.value * jumpWaitFactor;
		Invoke ("Jump", waitTime);
	}
	void Jump(){
		var bod = gameObject.GetComponent<Rigidbody2D> ();
		var tmpBodVel = bod.velocity;
		tmpBodVel.y += jumpHeight;
		bod.velocity = tmpBodVel;
	}
}
