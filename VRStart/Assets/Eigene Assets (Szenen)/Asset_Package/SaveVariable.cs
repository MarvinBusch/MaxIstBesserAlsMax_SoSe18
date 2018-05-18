using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveVariable : MonoBehaviour {

	static public bool Utopie;
	static public string letzteSzene = "";
	static public string aktuelleSzene = "";
	
	void Start(){
		Utopie = true;
		letzteSzene = "";
		aktuelleSzene = "Start";
	}
	
	public void SetUtopieTrue(){Utopie=true;}
	public void SetUtopieFalse(){Utopie=false;}

	static public void SceneChange(string sceneName){
		//letzteSzene = aktuelleSzene;
		aktuelleSzene = sceneName;
		letzteSzene = Application.loadedLevelName;
		Debug.Log ("Last Scene: " + letzteSzene + " | Aktuelle Szene: " + aktuelleSzene);
		Application.LoadLevel(sceneName);
	}
}