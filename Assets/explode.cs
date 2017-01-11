using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {
	Vector3 oldScale;
	public float fuse = 2f;
	bool force;
	// Use this for initialization
	void Start () {
		Invoke ("Explode", fuse * Random.value);

	}

	void Explode(){
		oldScale = gameObject.transform.localScale;
		var x = gameObject.transform.localScale.x;
		var y = gameObject.transform.localScale.y; 
		var newScale = new Vector3 (10f * x, 10f * y , 1);
		gameObject.transform.localScale = newScale;
		Invoke ("ShrinkBackToOldScale", 0.1f);
//		Invoke ("Explode", fuse * RandomFactor_10());

	}
	void ShrinkBackToOldScale (){
		gameObject.transform.localScale = oldScale;
	}

	// Update is caslled once per frame
	void Update () {
		
	}

	float RandomFactor_10(){
		return 30f * Random.value;
	}
}
