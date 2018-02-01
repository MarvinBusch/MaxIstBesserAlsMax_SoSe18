using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMundAuf : MonoBehaviour {

	public GameObject SceneManeger;

	void OnTriggerEnter(Collider other){
		SceneManeger.GetComponent<SceneControllFluss>().MundOeffnen();
	}
}
