// Dieses Script dreht den Kopf des Menschen mit der Kamera mit.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovment : MonoBehaviour {

	public GameObject Camera;

	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3 (Camera.transform.rotation.eulerAngles.x, Camera.transform.rotation.eulerAngles.y, Camera.transform.rotation.eulerAngles.z - 90);
		// Die Kamera ist auf der z-Achse um 90 Grad verdreht, daher werden die Rotationen der Kamera genommen, jedoch die Z-Achse angepasst.
	}
}
