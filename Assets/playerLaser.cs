using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLaser : MonoBehaviour {

	public GameObject ship;
	public float damage = 100f;
	public string side;
	public float shotDuration = 1f;

	public void Start () {
		Invoke("DestroySelf", shotDuration);
	}

	void OnCollisionEnter2D(Collision2D col) {	
		if (col.gameObject.GetComponent<followPC>()) {	
			var health = col
				.gameObject
				.GetComponent<Health> ();
			health.Damage (damage);
		}
	}

	void DestroySelf () {
		Destroy(gameObject);
	}

	public void Hit(){
		Destroy (gameObject);
	}

	public float GetDamage () {
		return damage;
	}

}

