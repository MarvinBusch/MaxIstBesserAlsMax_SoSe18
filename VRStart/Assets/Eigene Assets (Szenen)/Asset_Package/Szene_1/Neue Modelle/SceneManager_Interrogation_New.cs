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
	public GameObject TuerSound;
	int countAudio;




	private bool EndTuere=false;
	private bool Go = false;
	private bool end = false;
	private bool FlareIsShown = false;
	private bool Collides = false;
	private bool AudioPlay = false;
	private bool FirstHeadFinish = false;
	private bool Sceneswitch = false;

	private bool HeadTrack = false;
	private bool HeadTrackTime = false;



	// Use this for initialization
	void Start () {
		SaveVariable.letzteSzene="Start";
		// Es wird geprüft, aus welcher Szene man in die InterrogationSzene gekommen ist.
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

	// Vorherige Szene war die StartSzene.
	public void StartSceneSetup(){
		Debug.Log ("S: "+SaveVariable.letzteSzene);
		SaveVariable.Zeit_Seit_Start=0f;
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
		HeadTrack = false;
		HeadTrackTime = false;
		FirstHeadFinish = false;
		Sceneswitch = false;
		countAudio = 1;
	}

	public void ElDoradoSceneSetup (){
		Debug.Log ("E: "+SaveVariable.letzteSzene);

		Flare.GetComponent<LensFlare>().fadeSpeed = 1000;
		Flare.GetComponent<LensFlare>().brightness = FlareBrightness;
		for(int i=0; i<Lights.Length; i++){
			Lights[i].GetComponent<Light>().intensity = 0f;
		}

		MyTime = 0f;
		MyTimeHEad = 0f;

		Sceneswitch = false;
		HeadTrack = false;
		HeadTrackTime = false;
		Go = true;
		countAudio = 4;
	}

	public void MatrixSceneSetup (){
		Debug.Log ("M: "+SaveVariable.letzteSzene);

		Flare.GetComponent<LensFlare>().fadeSpeed = 1000;
		Flare.GetComponent<LensFlare>().brightness = FlareBrightness;
		for(int i=0; i<Lights.Length; i++){
			Lights[i].GetComponent<Light>().intensity = 0f;
		}

		MyTime = 0f;
		MyTimeHEad = 0f;

		Sceneswitch = false;
		HeadTrack = false;
		HeadTrackTime = false;
		Go = true;
		countAudio = 3;
	}

	public void FlussSceneSetup (){
		Debug.Log ("F: "+SaveVariable.letzteSzene);
	}

	// Update is called once per frame
	void Update () {
		SaveVariable.CountTime ();
		if (!HeadTrackTime) {
			MyTime += Time.deltaTime;
		} else {
			MyTimeHEad += Time.deltaTime;
		}
		// Siehe Start().
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
				AudioObj.GetComponent<AudioSource> ().clip = Resources.Load<AudioClip>("Schritte Sound");
				TuerSound.GetComponent<AudioSource> ().Play ();
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
				if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && !HeadTrack) {

					switch (countAudio) {
					case 1:
						MenschAnim.SetInteger ("State", 2);
						break;
					case 2:
						Debug.Log ("Audio2");
						break;
					case 3:
						Sceneswitch = true;
						MyTime = 0;
						break;
					}
					if (countAudio != 3) {
						loadClipIntoAudio (countAudio.ToString ());
						AudioObj.GetComponent<AudioSource> ().Play ();
						HeadTrack = true;
						MyTime = 0;
					}
				}
				if (MyTime > AudioObj.GetComponent<AudioSource> ().clip.length && HeadTrack) {
					Kamera.GetComponent<Nodding> ().ActivateHeadMovement ();
					HeadTrackTime = true;
					MyTimeHEad = 0f;
					MyTime = 0;
				}

				if (MyTimeHEad > Kamera.GetComponent<Nodding> ().Duration && Kamera.GetComponent<Nodding> ().Auswertung == true) {
					string loadstring;
					Debug.Log("Wahl: "+Kamera.GetComponent<Nodding> ().choice);
					switch (Kamera.GetComponent<Nodding> ().choice) {
					case -1:
						loadClipIntoAudio (countAudio.ToString () + "_O");
						SaveVariable.SetKooperation (-1);
						if (countAudio >= 2) {
							MenschAnim.SetInteger ("State", 4);
						}
						break;
					case 0:
						loadClipIntoAudio (countAudio.ToString () + "_J");
						SaveVariable.SetKooperation (1);
						break;
					case 1:
						loadClipIntoAudio (countAudio.ToString () + "_N");
						SaveVariable.SetKooperation (-2);
						if (countAudio >= 2) {
							MenschAnim.SetInteger ("State", 4);
						}
						break;
					}	
					countAudio++;
					AudioObj.GetComponent<AudioSource> ().Play ();
					HeadTrackTime = false;
					HeadTrack = false;
					MyTimeHEad = 0;
				}
				if (Sceneswitch) {
					if (Lights [0].GetComponent<Light> ().intensity <= 0) {
						Flare.GetComponent<Light>().intensity = 0f;
						SaveVariable.SceneChange ("Matrix");
					}
					for (int i = 0; i < Lights.Length; i++) {
						Lights [i].GetComponent<Light> ().intensity = (LightIntensity * -(MyTime / DurationLampe));
					}
				}
			}

		}
	}


	public void MatrixSceneUpdate (){
		//Debug.Log ("M: Update");
		if (Go) {
			if (Collides == true) {
				FlareIsShown = true;
				Flare.GetComponent<LensFlare>().fadeSpeed = 0;
			}
			if (MyTime < DurationLampe) {
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = LightIntensity * (MyTime / DurationLampe);
				}
			} else {
				Go = false;
				Debug.Log ("Light On! Go: "+ Go);
			}
		} else {
			
			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && !HeadTrack) {
				Debug.Log ("count: " + countAudio);

				loadClipIntoAudio (countAudio.ToString ());
				AudioObj.GetComponent<AudioSource> ().Play ();
				HeadTrack = true;
				MyTime = 0;
			}
			if (MyTime > AudioObj.GetComponent<AudioSource> ().clip.length && HeadTrack) {
				Kamera.GetComponent<Nodding> ().ActivateHeadMovement ();
				HeadTrackTime = true;
				MyTimeHEad = 0f;
				MyTime = 0;
			}

			if (MyTimeHEad > Kamera.GetComponent<Nodding> ().Duration && Kamera.GetComponent<Nodding> ().Auswertung == true) {
				string loadstring;
				Debug.Log ("Wahl: " + Kamera.GetComponent<Nodding> ().choice);
				switch (Kamera.GetComponent<Nodding> ().choice) {
				case -1:
					loadClipIntoAudio (countAudio.ToString () + "_O");
					break;
				case 0:
					loadClipIntoAudio (countAudio.ToString () + "_J");
					break;
				case 1:
					loadClipIntoAudio (countAudio.ToString () + "_N");
					break;
				}	
				countAudio++;
				AudioObj.GetComponent<AudioSource> ().Play ();
				HeadTrackTime = false;
				Sceneswitch = true;
				MyTimeHEad = 0;
			}
			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && Sceneswitch) {
				if (Lights [0].GetComponent<Light> ().intensity <= 0) {
					Flare.GetComponent<Light> ().intensity = 0f;
					SaveVariable.SceneChange ("ElDorado");
				}
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = (LightIntensity * -(MyTime / DurationLampe));
				}
			}
		}
	
	}

	public void ElDoradoSceneUpdate (){
		//Debug.Log ("E: Update");

		if (Go) {
			if (Collides == true) {
				FlareIsShown = true;
				Flare.GetComponent<LensFlare>().fadeSpeed = 0;
			}
			if (MyTime < DurationLampe) {
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = LightIntensity * (MyTime / DurationLampe);
				}
			} else {
				Go = false;
				Debug.Log ("Light On! Go: "+ Go);
			}
		} else {

			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && !HeadTrack) {
				Debug.Log ("count: " + countAudio);

				loadClipIntoAudio (countAudio.ToString ());
				AudioObj.GetComponent<AudioSource> ().Play ();
				HeadTrack = true;
				MyTime = 0;
			}
			if (MyTime > AudioObj.GetComponent<AudioSource> ().clip.length && HeadTrack) {
				Kamera.GetComponent<Nodding> ().ActivateHeadMovement ();
				HeadTrackTime = true;
				MyTimeHEad = 0f;
				MyTime = 0;
			}

			if (MyTimeHEad > Kamera.GetComponent<Nodding> ().Duration && Kamera.GetComponent<Nodding> ().Auswertung == true) {
				string loadstring;
				Debug.Log ("Wahl: " + Kamera.GetComponent<Nodding> ().choice);
				switch (Kamera.GetComponent<Nodding> ().choice) {
				case -1:
					loadClipIntoAudio (countAudio.ToString () + "_O");
					break;
				case 0:
					loadClipIntoAudio (countAudio.ToString () + "_J");
					break;
				case 1:
					loadClipIntoAudio (countAudio.ToString () + "_N");
					break;
				}	
				countAudio++;
				AudioObj.GetComponent<AudioSource> ().Play ();
				HeadTrackTime = false;
				Sceneswitch = true;
				MyTimeHEad = 0;
			}
			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && Sceneswitch) {
				if (Lights [0].GetComponent<Light> ().intensity <= 0) {
					Flare.GetComponent<Light> ().intensity = 0f;
					SaveVariable.SceneChange ("Fluss");
				}
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = (LightIntensity * -(MyTime / DurationLampe));
				}
			}
		}

	}

	public void FlussSceneUpdate (){
		//Debug.Log ("F: Update");
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
		AudioObj.GetComponent<AudioSource> ().clip = Resources.Load<AudioClip>(fileName);
		Debug.Log ("NameAudio: " + AudioObj.GetComponent<AudioSource> ().clip.name);
	}
}

