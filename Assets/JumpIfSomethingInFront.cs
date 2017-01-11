using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIfSomethingInFront : MonoBehaviour {
	public float jumpHeight;
	public float whiskerLength;
	public float margin = 10f;
	int availableJumps = 0;
	int maxAvailableJumps = 4;


	void Start () {
		InvokeRepeating ("JumpIfWhisker",1f, 1f);
		InvokeRepeating ("GetNewJump", 1f, 2f);

	}
	void GetNewJump(){
		availableJumps += 1;
	}

	void JumpIfWhisker(){

		var rightRayStartingPoint = new Vector3 (transform.position.x + margin, transform.position.y, transform.position.z);
		var leftRayStartingPoint = new Vector3( transform.position.x - margin, transform.position.y, transform.position.z);

		RaycastHit2D hitRight = Physics2D.Raycast(rightRayStartingPoint, Vector2.right, whiskerLength);
		RaycastHit2D hitLeft = Physics2D.Raycast(leftRayStartingPoint, Vector2.left, whiskerLength);

		if ( ( hitRight.collider != null && hitRight.transform.gameObject.tag == "Player" )|| ( hitLeft.collider != null && hitLeft.transform.gameObject.tag == "Player" )) {

			Jump ();
		} 

	}

	void Jump(){
		availableJumps -= 1;
		var bod = gameObject.GetComponent<Rigidbody2D> ();
		var velX = bod.velocity.x;
		var velY = bod.velocity.y;
		bod.velocity = new Vector3 (velX, velY + jumpHeight, 0f);
	}
}
