using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kugelschneller : MonoBehaviour {

	public float MaxSpeed;
	public float TimeToMaxSpeed;
	public float startDrag;

	void Start(){
		GetComponent<Rigidbody> ().drag = startDrag;
	}

	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody> ().drag > MaxSpeed) {
			GetComponent<Rigidbody> ().drag -= ((startDrag-MaxSpeed)/TimeToMaxSpeed) * Time.deltaTime;
		}
	}
}

