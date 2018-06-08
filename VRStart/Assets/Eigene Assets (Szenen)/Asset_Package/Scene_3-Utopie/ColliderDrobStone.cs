using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDrobStone : MonoBehaviour {

	public GameObject HandObj;

	void OnTriggerEnter(Collider other){
		HandObj.GetComponent<GrabStone>().DropStone();
	}
}
