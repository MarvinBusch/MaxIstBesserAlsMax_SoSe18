using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_Interrogation_New : MonoBehaviour {

	protected float MyTime = 0f;
	protected float MyTimeHEad = 0f;
	public GameObject Flare;
	protected float brightness;
	protected bool AudioEnded=false;
	public GameObject Türe;
	public GameObject Lampe;
	public GameObject Kamera;

	public float StartTime = 5.0f;
	public float DurationLampe = 5.0f;

	public float WaitTime = 5.0f;
	public float DurationTuere = 5f;

	private Animator MenschAnim;
	public GameObject MenschTisch;

	public Transform[] Lights;
	public float LightIntensity = 1f;

	public float FlareIntensity = 500f;
	public float FlareBrightness = 5f;

	private bool TuereAuf = false;
	private bool StartTuere = false;

	public GameObject AudioObj;
	int countAudio;




	private bool EndTuere=false;
	private bool Go = false;
	private bool end = false;
	private bool FlareIsShown = false;
	private bool Collides = false;
	private bool AudioPlay = false;

	private bool HeadTrack = false;



	// Use this for initialization
	void Start () {
		SaveVariable.letzteSzene="Start";
		if(SaveVariable.letzteSzene!=""){
			switch (SaveVariable.letzteSzene) {
			case "Start":
				StartSceneSetup ();
				break;
			case "Start_zug":
				StartSceneSetup ();
				break;
			case "ElDorado":
				ElDoradoSceneSetup ();
				break;
			case "BladeRunner_neu":
				MatrixSceneSetup ();
				break;
			case "Tomorrowland":
				MatrixSceneSetup ();
				break;
			case "Fluss":
				FlussSceneSetup ();
				break;
			}
		}
	}

	public void StartSceneSetup(){
		Debug.Log ("S: "+SaveVariable.letzteSzene);
		brightness = Flare.GetComponent<LensFlare>().brightness;
		Flare.GetComponent<Light>().intensity = 0f;
		Flare.GetComponent<LensFlare>().brightness = 0f;
		Flare.GetComponent<LensFlare>().fadeSpeed = 1000;

		MyTime = 0f;
		MyTimeHEad = 0f;

		for(int i=0; i<Lights.Length; i++){
			Lights[i].GetComponent<Light>().intensity = 0f;
		}

		MenschAnim = MenschTisch.GetComponent<Animator>();
		MenschTisch.SetActive (false);
		TuereAuf = false;
		StartTuere = false;
		HeadTrack = true;
		countAudio = 1;
	}

	public void ElDoradoSceneSetup (){
		Debug.Log ("E: "+SaveVariable.letzteSzene);
	}

	public void MatrixSceneSetup (){
		Debug.Log ("M: "+SaveVariable.letzteSzene);

		for(int i=0; i<Lights.Length; i++){
			Lights[i].GetComponent<Light>().intensity = 0f;
		}

		MyTimeHEad = 0f;

		HeadTrack = false;
		Go = true;
	}

	public void FlussSceneSetup (){
		Debug.Log ("F: "+SaveVariable.letzteSzene);
	}

	// Update is called once per frame
	void Update () {
		SaveVariable.CountTime ();
		MyTime += Time.deltaTime;
		MyTimeHEad += Time.deltaTime;
		if (SaveVariable.letzteSzene != "") {
			switch (SaveVariable.letzteSzene) {
			case "Start":
				StartSceneUpdate ();
				break;
			case "Start_zug":
				StartSceneUpdate ();
				break;
			case "ElDorado":
				ElDoradoSceneUpdate ();
				break;
			case "BladeRunner_neu":
				MatrixSceneUpdate ();
				break;
			case "Tomorrowland":
				MatrixSceneUpdate ();
				break;
			case "Fluss":
				FlussSceneUpdate ();
				break;
			}
		}
	}

	public void StartSceneUpdate (){
		if (EndTuere == false) {
			if (MyTime > WaitTime && StartTuere == false) {
				MyTime = 0;
				StartTuere = true;
				MenschTisch.SetActive (true);
				MenschAnim.SetInteger ("State", 1);
			}
			if (MyTime > DurationTuere && StartTuere == true) {
				EndTuere = true;
				Türe.GetComponent<Transform> ().eulerAngles = new Vector3 (-90, 0, 90);
				MyTime = 0;
				MenschAnim.SetInteger ("State", 0);
			}		
			if (StartTuere == true) {
				if (TuereAuf == false) {
					if (MyTime > (DurationTuere / 2)) {
						TuereAuf = true;
					} else {
						Türe.GetComponent<Transform> ().eulerAngles = new Vector3 (-90, 0, 90 + (90 * (MyTime / (DurationTuere / 2))));
					}
				}
				if (TuereAuf == true) {
					Türe.GetComponent<Transform> ().eulerAngles = new Vector3 (-90, 0, 270 + (-90 * (MyTime / (DurationTuere / 2))));
				}
			}
		} else {		
			Türe.GetComponent<Transform> ().eulerAngles = new Vector3 (-90, 0, 90);
			if (FlareIsShown == true) {
				Flare.GetComponent<LensFlare> ().fadeSpeed = 0;
			}
			if (end == false) {
				if (MyTime > WaitTime && Go == false) {
					Lampe.GetComponent<AudioSource> ().Play ();
					MyTime = 0;
					Go = true;
					Flare.GetComponent<Light> ().intensity = FlareIntensity;
					Flare.GetComponent<LensFlare> ().brightness = FlareBrightness;
					if (Collides == true) {
						FlareIsShown = true;
					}
				}
				if (MyTime > DurationLampe && Go == true) {
					end = true;
				}
				if (Go == true) {
					for (int i = 0; i < Lights.Length; i++) {
						Lights [i].GetComponent<Light> ().intensity = LightIntensity * (MyTime / DurationLampe);
					}
				}
			}
			if (end == true) {
				if (AudioPlay == false) {
					loadClipIntoAudio (countAudio.ToString());
					AudioObj.GetComponent<AudioSource> ().Play ();
					MyTime = 0;
					MenschAnim.SetInteger ("State", 2);
					AudioPlay = true;
				}
				if (MyTime > AudioObj.GetComponent<AudioSource> ().clip.length) {
					if (HeadTrack) {
						Kamera.GetComponent<Nodding> ().ActivateHeadMovement ();
						HeadTrack = false;
						MyTimeHEad = 0f;
					}
					if (MyTimeHEad > Kamera.GetComponent<Nodding> ().Duration) {
						string loadstring;
						switch (Kamera.GetComponent<Nodding> ().choice) {
						case -1:
							loadClipIntoAudio (countAudio.ToString() + "_O");
							break;
						case 0:
							loadClipIntoAudio (countAudio.ToString() + "_J");
							break;
						case 1:
							loadClipIntoAudio (countAudio.ToString() + "_N");
							break;
						}
						countAudio++;
						AudioPlay = false;
						MyTimeHEad = 0;
						HeadTrack = true;
					}
				}

			}
		}
	}

	public void MatrixSceneUpdate (){
		//Debug.Log ("M: Update");
		if (Go) {
			if (MyTime < DurationLampe) {
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = LightIntensity * (MyTime / DurationLampe);
				}
			} else {
				Go = false;
				HeadTrack = true;
				Debug.Log ("Light On");
			}
		} else if (HeadTrack) {
			Kamera.GetComponent<Nodding> ().ActivateHeadMovement ();
			HeadTrack = false;
		}
	}

	public void ElDoradoSceneUpdate (){
		Debug.Log ("E: Update");
	}

	public void FlussSceneUpdate (){
		Debug.Log ("F: Update");
	}

	public void DetectCollision(){
		Collides = true;
		if(Go==true&&MyTime>0){
			FlareIsShown = true;
		}
	}
	public void DetectDeCollision(){
		Collides = false;
	}

	void loadClipIntoAudio(string NewAudio){
		string fileName = "Text_Inter/" + NewAudio;
		Debug.Log ("Filename: " + fileName);
		AudioObj.GetComponent<AudioSource> ().clip = Resources.Load<AudioClip>(fileName);
		Debug.Log ("NameAudio: " + AudioObj.GetComponent<AudioSource> ().clip.name);
	}

}

