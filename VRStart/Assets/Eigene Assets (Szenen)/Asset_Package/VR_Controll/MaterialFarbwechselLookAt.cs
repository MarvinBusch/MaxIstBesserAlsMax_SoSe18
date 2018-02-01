using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFarbwechselLookAt : MonoBehaviour {

	public Material noLooky;
	public Material eyeSpy;
	
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material = noLooky;
	}
		
	public void TotallyWatching()
	{
		GetComponent<Renderer>().material = eyeSpy;
	}
	
	public void NotEvenLooking()
	{
		GetComponent<Renderer>().material = noLooky;
	}
}
