using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaro : MonoBehaviour {
	public float latency = 3f;
	public GameObject maro;
	GameObject newMaro;
	// Use this for initialization
	void Start () {
		InvokeRepeating( "Spawn",1f, latency);
	}
	
	void Spawn (){
		newMaro = Instantiate(maro, gameObject.transform.position, Quaternion.identity);

	}
	void KillMaro(){
		Destroy (newMaro);
	}
}
