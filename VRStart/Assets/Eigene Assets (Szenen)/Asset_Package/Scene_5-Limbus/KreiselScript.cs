using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KreiselScript : MonoBehaviour {

	float rotate;
	public float start, fallen;
	bool drehen = true;

	void Start(){
		rotate = start;
		drehen = true;
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, rotate);

		if (!drehen && rotate > fallen) {
			rotate -= start / 1 * Time.deltaTime;
		}
		if (drehen && rotate < start) {
			rotate += start / 2 * Time.deltaTime;
		}
	}

	public void KreiselFaellt(){
		drehen = false;
	}

	public void KreiselAufrecht(){
		drehen = true;
	}
}
