using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRising : MonoBehaviour {

	public GameObject SceneManeger;

	void OnTriggerEnter(){
		SceneManeger.GetComponent<SceneControllFluss>().ObjectRise();
	}
}
