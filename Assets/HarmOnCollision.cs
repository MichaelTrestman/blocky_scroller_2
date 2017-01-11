using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmOnCollision : MonoBehaviour {
	public float damage = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player")
			col.gameObject.GetComponent<Health> ().Damage (damage);
		
	}
}
