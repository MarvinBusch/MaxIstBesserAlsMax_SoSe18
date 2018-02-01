using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMundZu : MonoBehaviour {

	public GameObject SceneManeger;

	void OnTriggerEnter(Collider other){
		SceneManeger.GetComponent<SceneControllFluss>().MundZu();
	}
}
