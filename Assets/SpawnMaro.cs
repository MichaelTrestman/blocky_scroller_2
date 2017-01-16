using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaro : MonoBehaviour {
	public float latency = 3f;
	public GameObject maro;
	GameObject newMaro;
	// Use this for initialization
	void Start () {
		SpawnRandomlyForAWhile ();
		latency *= 0.5f + Random.value;
	}

	void SpawnRandomlyForAWhile(){
		latency *= 0.5f + Random.value;
		InvokeRepeating( "Spawn", 0.1f, latency);
		Invoke ("CancelInvocationsThenReInvoke", 3f*latency);
	}

	void CancelInvocationsThenReInvoke(){
		CancelInvoke ("Spawn");
		SpawnRandomlyForAWhile ();
	}
	void Spawn (){
		newMaro = Instantiate(maro, gameObject.transform.position, Quaternion.identity);

	}
	void KillMaro(){
		Destroy (newMaro);
	}
}
