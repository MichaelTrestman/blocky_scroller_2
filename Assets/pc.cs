using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pc : MonoBehaviour {
	public float moveRate = 1;
	public float firingRate = 1;
	public float jumpPower = 2;
	int availableJumps = 0;
	int maxAvailableJumps = 4;
	bool pressable = true;
	Quaternion pointingDir;
	public GameObject projectile;
	public float projectileSpeed = 100f;
	public Camera camera;
	bool isTeleporting = false;
	bool isLazering = false;

	void OnCollisionEnter2D (Collision2D col) {
		availableJumps = maxAvailableJumps;
	}
		
	void Update () {
		rotate ();
		moveWithKeys ();	
		if (Input.GetKey(KeyCode.Space)){
			FireProjectile ();
		}
	}
	public bool IsTeleporting(){
		return isTeleporting;
	}
	void rotate () {
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		pointingDir = Quaternion.AngleAxis(angle, Vector3.forward);
	}
		
	void moveWithKeys (){

		//		if( !( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)  ) ){
		//			return;
		//		}

		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		var vel = rb.velocity;

		if (Input.GetKey(KeyCode.D) ){
			vel.x += moveRate;		
		} else if (Input.GetKey(KeyCode.A) ){
			vel.x -= moveRate;
		} 

		if (Input.GetKey(KeyCode.W) ){
			// pressable should really be like canJump() that returns true only if you're touching something and also it's under you i guess store that as state on collision
			if (availableJumps > 0 && pressable) {
				vel.y = jumpPower;
				availableJumps -= 1;
				pressable = false;
				Invoke ("makePressableTrue", .15f);
			}
		} else if (Input.GetKey(KeyCode.S) ){
			vel.y -= moveRate;
		} else if (Input.GetKey(KeyCode.T)){
			Teleport();
		}

		rb.velocity = vel;



	}

	void Teleport(){
		var tmpPos = camera.ScreenToWorldPoint(Input.mousePosition);
		tmpPos.z = 0f;
		gameObject.transform.position = tmpPos;
		isTeleporting = true;
		Invoke ("MakeIsTeleportingFalse", 1f);
	}
	void MakeIsTeleportingFalse (){
		isTeleporting = false;
	}
	void MakeIsLazeringFalse (){
		isLazering = false;
	}
	void FireProjectile() {
		if (isLazering){return;}
		GameObject thisProjectile = Instantiate(projectile, transform.position, pointingDir) as GameObject;

		thisProjectile.transform.rotation = pointingDir;

		thisProjectile.GetComponent<Rigidbody2D> ().velocity = (Vector2)(pointingDir * new Vector3 (projectileSpeed, 0, 0));
//		AudioSource.PlayClipAtPoint (fireSound, transform.position);
		isLazering = true;
		Invoke ("MakeIsLazeringFalse", 0.6f);

	}

	void makePressableTrue (){
		pressable = true;
	}
	void jump (){
	}

}
