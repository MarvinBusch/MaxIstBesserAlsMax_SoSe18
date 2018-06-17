using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotation : MonoBehaviour {

	float StartRotation;
	public GameObject Raumschiff;

	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -Raumschiff.transform.eulerAngles.y + 90);
		SaveVariable.CountTime ();
	}
}
