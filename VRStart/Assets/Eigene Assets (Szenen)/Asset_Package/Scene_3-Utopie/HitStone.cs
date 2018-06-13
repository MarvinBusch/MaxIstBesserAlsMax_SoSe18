using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStone : MonoBehaviour {
	public string scenename = "Limbus";

	void OnTriggerEnter(Collider other){
		SaveVariable.SceneChange(scenename);
	}
}
