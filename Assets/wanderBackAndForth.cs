using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderBackAndForth : MonoBehaviour {
	bool wanderDirectionIsLeft = true;
	public float walkSpeed = 20f;
	public float switchDirectionFrequency = 10f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ( "SwitchWanderDirections", 1f * Random.value, switchDirectionFrequency);
	}
	public void SwitchWanderDirections (){ wanderDirectionIsLeft = !wanderDirectionIsLeft; }
	
	// Update is called once per frame
	void Update () {
		var walkX = walkSpeed;
		if (wanderDirectionIsLeft) {
			walkX *= -1f;
		}
		var walk = new Vector3 (walkX,walkX,0f);
		gameObject.GetComponent<Rigidbody2D> ().velocity = walk;
	}
}
