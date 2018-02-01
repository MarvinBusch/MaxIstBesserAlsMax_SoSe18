using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKinder : MonoBehaviour {

	public GameObject SceneManeger;

	void OnTriggerEnter(){
		SceneManeger.GetComponent<SceneControllFluss>().Kinder();
	}
}
