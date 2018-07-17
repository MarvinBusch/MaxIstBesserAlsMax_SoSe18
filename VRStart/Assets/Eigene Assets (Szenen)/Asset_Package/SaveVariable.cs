using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveVariable : MonoBehaviour {

	static public bool Utopie = true;
	static public float Zeit_Seit_Start = 0f;
	static public string letzteSzene = "";
	static public string aktuelleSzene = "";
	static public int kooperation = -3;

	public void SetUtopieTrue(){Utopie=true;}
	public void SetUtopieFalse(){Utopie=false;}

	static public void SceneChange(string sceneName){
		if (kooperation <= -6 && Application.loadedLevelName == "Fluss") {
			sceneName = "Interrogation2";
		}
		letzteSzene = Application.loadedLevelName;
		Debug.Log ("Last Scene: " + letzteSzene + " | Aktuelle Szene: " + aktuelleSzene);
		SceneManager.LoadScene (sceneName);
	}

	static public void CountTime(){
		Zeit_Seit_Start += Time.deltaTime;
	}

	static public void SetKooperation (int koop){
		kooperation += koop;
		Debug.Log ("koop: " + kooperation);
	}
}