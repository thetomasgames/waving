using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	public float speed = 5f;
	public float jumpForce = 100f;
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton ("Jump")) {
			rb.AddExplosionForce (jumpForce, transform.position + Vector3.down, 2f);
		}
		rb.AddTorque (Input.GetAxis ("Horizontal") * speed, 0, Input.GetAxis ("Vertical") * speed);
	}
}