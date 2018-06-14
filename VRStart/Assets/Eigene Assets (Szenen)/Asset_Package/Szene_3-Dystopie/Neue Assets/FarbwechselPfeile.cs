using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarbwechselPfeile : MonoBehaviour {

	public Material notactive;
	public Material active;
	public Material lookat;

	// Use this for initialization
	void Start () {
		Deaktivieren ();
	}
		
	public void Aktivieren()
	{
		GetComponent<MeshCollider> ().enabled = true;
		GetComponent<Renderer>().material = active;
	}

	public void Deaktivieren()
	{
		GetComponent<MeshCollider> ().enabled = false;
		GetComponent<Renderer>().material = notactive;
	}

	public void TotallyWatching()
	{
		GetComponent<Renderer>().material = lookat;
	}

	public void NotEvenLooking()
	{
		GetComponent<Renderer>().material = active;
	}
}
