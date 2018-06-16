using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTime : MonoBehaviour {

	public float myTime = 0f;

	void Start () {
		myTime = 0f;
		changeDisplayTime ();
		changeColor (Color.green);
	}

	void Update () {
		if (SaveVariable.Zeit_Seit_Start > 0) {myTime = SaveVariable.Zeit_Seit_Start;} 
		else {myTime += Time.deltaTime;}

		changeDisplayTime ();
	}

	void changeDisplayTime(){
		GetComponent<TextMesh> ().text = (Mathf.Floor(myTime/60)).ToString("F0") + ":" + (myTime%60).ToString("00");
		//GetComponent<TextMesh> ().text = (Mathf.Floor(myTime/60)).ToString("F0") + ":" + (myTime%60).ToString("F1");
	}

	public void changeColor(Color neueFarbe){
		GetComponent<Renderer> ().material.color = neueFarbe;
	}

	public Color getColor(){
		return GetComponent<Renderer> ().material.color;
	}
}
