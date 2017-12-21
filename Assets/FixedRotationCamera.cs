using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotationCamera : MonoBehaviour {
	
	public Transform target;

	private Vector3 offset;
	
	void Start(){
		offset=transform.position-target.position;
	}
	
	void Update () {
		
	}

	void LateUpdate(){
		transform.position=target.position+offset;
	}
}
