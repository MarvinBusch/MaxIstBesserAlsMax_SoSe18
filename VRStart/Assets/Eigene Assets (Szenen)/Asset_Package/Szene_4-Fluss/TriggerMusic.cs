using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour {

	public GameObject SceneManeger;

	void OnTriggerEnter(Collider other){
		SceneManeger.GetComponent<SceneControllFluss>().StartMusic();
	}
}
