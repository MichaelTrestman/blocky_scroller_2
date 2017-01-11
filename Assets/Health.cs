using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float maxHealth;
	float currentHealth;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;

	}
	public float GetCurrentHealth(){
		return currentHealth;
	}
	public void Damage (float points){
		currentHealth -= points;
		if (currentHealth <= 0f) {
			Destroy (gameObject);
			Die ();
		}
	}

	public void Heal (float points){
		currentHealth += points;
	}

	void Die(){
		if (gameObject.GetComponent<pc> () != null) {
			Application.LoadLevel (Application.loadedLevel);
		}
		Destroy (gameObject);
	}
}
