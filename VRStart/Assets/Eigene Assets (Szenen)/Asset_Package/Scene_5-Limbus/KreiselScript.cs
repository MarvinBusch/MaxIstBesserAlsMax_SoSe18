using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KreiselScript : MonoBehaviour {


	public float rotate;

	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, rotate);
	}

	public void KreiselFaellt(){
		rotate = 5;
	}
}
