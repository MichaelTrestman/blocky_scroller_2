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
		if (col.collider.gameObject.GetComponent<playerLaser> ()) {
			return;
		}

		availableJumps = maxAvailableJumps;
		

	}
		
	void Update () {
		rotate ();
		moveWithKeys ();	
		if (Input.GetKey(KeyCode.Space)){
			FireProjectile ();
		}

//		if (Input.GetKey(KeyCode.L) ){
			if (Input.GetKey(KeyCode.Keypad0)){
				Application.LoadLevel (0);
			} else if (Input.GetKey(KeyCode.Keypad1)){
				Application.LoadLevel (1);
			} else if (Input.GetKey(KeyCode.Keypad2)){
				Application.LoadLevel (2);
			} else if (Input.GetKey(KeyCode.Keypad3)){
				Application.LoadLevel (3);
			} else if (Input.GetKey(KeyCode.Keypad4)){
				Application.LoadLevel (4);
			} else if (Input.GetKey(KeyCode.Keypad5)){
				Application.LoadLevel (5);
			} else if (Input.GetKey(KeyCode.Keypad6)){
				Application.LoadLevel (6);
			} else if (Input.GetKey(KeyCode.Keypad7)){
				Application.LoadLevel (7);
			}
				
//		} 

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
		if (isTeleporting) {
			return;
		}
		if (Time.timeScale < 1) {
			return;
		}


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
		Invoke ("MakeIsLazeringFalse", 0.2f);

	}

	void makePressableTrue (){
		pressable = true;
	}
	void jump (){
	}

}
