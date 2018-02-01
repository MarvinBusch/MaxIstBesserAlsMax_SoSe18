using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovment : MonoBehaviour {

	public GameObject Camera;
	
	// Update is called once per frame
	void Update () {
		if(transform.eulerAngles != Camera.transform.rotation.eulerAngles)
		{
			transform.eulerAngles = Camera.transform.rotation.eulerAngles;
		}
	}
}
