using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrueckenOeffnen : MonoBehaviour {

	bool lookat = false;
	public bool NachLinks = false;
	float multi = 1;
	public float openDuration = 1f;
	float BeginRotation;

	void Start(){
		BeginRotation = transform.eulerAngles.z;
	}

	void Update(){
		if (lookat == true) {
			if (NachLinks == false) {
				if ((transform.eulerAngles.z <= BeginRotation + 90 && multi >= 0) || (transform.eulerAngles.z >= BeginRotation && multi <= 0)) {
					transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + multi * (90 / openDuration) * Time.deltaTime);
				} else {
					lookat = false;
				}
			} else {
				if ((transform.eulerAngles.z >= BeginRotation - 90 && multi >= 0) || (transform.eulerAngles.z <= BeginRotation && multi <= 0)) {
					transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - multi * (90 / openDuration) * Time.deltaTime);
				} else {
					lookat = false;
				}
			}
		}
	}

	public void Oeffnen(){
		lookat = true;
		multi = 1;
	}

	public void Schliessen(){
		multi = multi * -1;
		lookat = true;
	}
}
