using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expire : MonoBehaviour {
	public float fuse = 3f;
	// Use this for initialization
	void Start () {
		Invoke ("Die", fuse);
	}
	void Die (){
		Destroy (gameObject);
	}
}
