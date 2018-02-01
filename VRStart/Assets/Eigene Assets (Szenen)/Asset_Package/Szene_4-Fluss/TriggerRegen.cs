using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRegen : MonoBehaviour {
	
	public GameObject SceneManeger;

	void OnTriggerEnter(){
		SceneManeger.GetComponent<SceneControllFluss>().StartRegen();
	}
}
