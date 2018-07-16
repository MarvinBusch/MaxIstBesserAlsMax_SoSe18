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
	public GameObject PistolenLicht;

	public float FlareIntensity = 500f;
	public float FlareBrightness = 5f;

	private bool TuereAuf = false;
	private bool StartTuere = false;

	public GameObject AudioObj;
	public GameObject TuerSound;
	int countAudio;

	public GameObject Pistole;
	public GameObject Pistole_Container;
	public GameObject Magazin;
	public GameObject Kugel;

	public GameObject Explosion;




	private bool EndTuere=false;
	private bool Go = false;
	private bool end = false;
	private bool FlareIsShown = false;
	private bool Collides = false;
	private bool AudioPlay = false;
	private bool FirstHeadFinish = false;
	private bool Sceneswitch = false;
	private bool Schlag = false;

	private bool HeadTrack = false;
	private bool HeadTrackTime = false;



	// Use this for initialization
	void Start () {
		//SaveVariable.letzteSzene="Fluss";
		if (SaveVariable.kooperation>-4) {
			Debug.Log ("Pistole auseinander");

			Magazin.transform.SetParent (Pistole_Container.transform);
			Kugel.transform.SetParent (Pistole_Container.transform);

			Pistole.transform.localPosition = new Vector3(-7f, -0.5f, 6.5f);
			Magazin.transform.localPosition = new Vector3(-6f, 0.1f, 5.5f);
			Kugel.transform.localPosition = new Vector3(-5.4f, 0.1f, 6.4f);

			Pistole.transform.localEulerAngles = new Vector3(0, -95, 0);
			Magazin.transform.localEulerAngles = new Vector3(0, 155, -90);
			Kugel.transform.localEulerAngles = new Vector3(-180, -85, 0);
		}
		if (SaveVariable.kooperation <= -4) {
			Debug.Log ("Pistole zusammen");

			Magazin.transform.SetParent (Pistole.transform);
			Kugel.transform.SetParent (Pistole.transform);

			Magazin.transform.localPosition = new Vector3 (-0.058f, 0.125f, -0.089f);
			Kugel.transform.localPosition = new Vector3 (0.168f, 0.125f, -0.178f);
			Magazin.transform.localEulerAngles = new Vector3 (0, 50, -90);
			Kugel.transform.localEulerAngles = new Vector3 (0, 140, 0);

			if (SaveVariable.kooperation <= -6) {
				Pistole.transform.localPosition = new Vector3 (-3.029f, 4.693f, 5.495f);
				Pistole.transform.localEulerAngles = new Vector3 (-31.254f, -124.0f, 89.0f);
			}else{
				Pistole.transform.localPosition = new Vector3 (-7.4f, -0.5f, 5.65f);
				Pistole.transform.localEulerAngles = new Vector3 (0, -65, 0);
			}
		}
		PistolenLicht.GetComponent<Light> ().enabled = false;
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
		Schlag = false;
		countAudio = 1;
	}

	public void ElDoradoSceneSetup (){
		Debug.Log ("E: "+SaveVariable.letzteSzene);

		Flare.GetComponent<LensFlare>().fadeSpeed = 1000;
		Flare.GetComponent<LensFlare>().brightness = FlareBrightness;
		for(int i=0; i<Lights.Length; i++){
			Lights[i].GetComponent<Light>().intensity = 0f;
		}

		MenschAnim = MenschTisch.GetComponent<Animator>();

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

		MenschAnim = MenschTisch.GetComponent<Animator>();

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

		Flare.GetComponent<LensFlare>().fadeSpeed = 10;
		Flare.GetComponent<LensFlare>().brightness = FlareBrightness;
		for(int i=0; i<Lights.Length; i++){
			Lights[i].GetComponent<Light>().intensity = 1f;
		}
		MenschAnim = MenschTisch.GetComponent<Animator>();
		MenschAnim.SetInteger ("State", 6);

		Explosion.SetActive(false);

		MyTime = 0f;
		MyTimeHEad = 0f;

		Sceneswitch = false;
		HeadTrack = false;
		HeadTrackTime = false;
		Go = true;
		countAudio = 5;
	}

	// Update is called once per frame
	void Update () {
		SaveVariable.CountTime ();
		if (!HeadTrackTime) {
			MyTime += Time.deltaTime;
		} else {
			MyTimeHEad += Time.deltaTime;
		}

		if (SaveVariable.kooperation<=-2 && !PistolenLicht.GetComponent<Light> ().enabled && SaveVariable.kooperation >-6) {
			Debug.Log ("Licht An");
			PistolenLicht.GetComponent<Light> ().enabled = true;
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
				AudioObj.GetComponent<AudioSource> ().Play ();
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
						if (!Sceneswitch) {
							if (Schlag) {
								MenschAnim.SetInteger ("State", 4);
								AudioObj.GetComponent<AudioSource> ().clip = Resources.Load<AudioClip> ("Schlag");
								AudioObj.GetComponent<AudioSource> ().Play ();
							} else {
								MenschAnim.SetInteger ("State", 2);
							}
							Sceneswitch = true;
							MyTime = 0;
						}
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
					Debug.Log ("Wahl: " + Kamera.GetComponent<Nodding> ().choice);
					switch (Kamera.GetComponent<Nodding> ().choice) {
					case -1:
						loadClipIntoAudio (countAudio.ToString () + "_O");
						SaveVariable.SetKooperation (-1);
						if (countAudio >= 2) {
							Schlag = true;
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
							Schlag = true;
						}
						break;
					}	
					countAudio++;
					AudioObj.GetComponent<AudioSource> ().Play ();
					HeadTrackTime = false;
					HeadTrack = false;
					MyTimeHEad = 0;
				}
				if (MyTime > MenschTisch.GetComponent<Animator> ().GetCurrentAnimatorClipInfo (0) [0].clip.length && !Sceneswitch) {
					MenschAnim.SetInteger ("State", 0);
				}
				if (MyTime > AudioObj.GetComponent<AudioSource> ().clip.length && Sceneswitch) {
					Flare.GetComponent<Light> ().intensity = 0f;
					for (int i = 0; i < Lights.Length; i++) {
						Lights [i].GetComponent<Light> ().intensity = 0;
					}
					SaveVariable.SceneChange ("Matrix");
				} 
			}

		}
	}


	public void MatrixSceneUpdate (){
		//Debug.Log ("M: Update");
		if (Go) {
			if (Collides == true) {
				FlareIsShown = true;
				Flare.GetComponent<LensFlare> ().fadeSpeed = 0;
			}
			if (MyTime < DurationLampe) {
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = LightIntensity * (MyTime / DurationLampe);
				}
			} else {
				Go = false;
				Debug.Log ("Light On! Go: " + Go);
			}
		} else {
			
			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false  && !Sceneswitch) {
				if (Schlag) {
					Flare.GetComponent<Light> ().intensity = 0f;
					for (int i = 0; i < Lights.Length; i++) {
						Lights [i].GetComponent<Light> ().intensity = 0;
					}
					SaveVariable.SceneChange ("ElDorado");
				}
				if (!HeadTrack) {
					Debug.Log ("count: " + countAudio);
					loadClipIntoAudio (countAudio.ToString ());
					AudioObj.GetComponent<AudioSource> ().Play ();
					HeadTrack = true;
					MyTime = 0;
				} else if(!HeadTrackTime){
					Kamera.GetComponent<Nodding> ().ActivateHeadMovement ();
					HeadTrackTime = true;
					MyTimeHEad = 0f;
					MyTime = 0;
				} 
			}

			if (MyTimeHEad > Kamera.GetComponent<Nodding> ().Duration && Kamera.GetComponent<Nodding> ().Auswertung == true) {
				Debug.Log ("Wahl: " + Kamera.GetComponent<Nodding> ().choice);
				switch (Kamera.GetComponent<Nodding> ().choice) {
				case -1:
					loadClipIntoAudio (countAudio.ToString () + "_O");
					SaveVariable.SetKooperation (-1);
					Schlag = true;
					break;
				case 0:
					loadClipIntoAudio (countAudio.ToString () + "_J");
					SaveVariable.SetKooperation (1);
					break;
				case 1:
					loadClipIntoAudio (countAudio.ToString () + "_N");
					SaveVariable.SetKooperation (-2);
					Schlag = true;
					break;
				}	
				countAudio++;
				AudioObj.GetComponent<AudioSource> ().Play ();
				HeadTrackTime = false;
				Sceneswitch = true;
				MyTimeHEad = 0;
			}
			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && Sceneswitch && !Schlag) {
				if (Lights [0].GetComponent<Light> ().intensity <= 0) {
					Flare.GetComponent<Light> ().intensity = 0f;
					SaveVariable.SceneChange ("ElDorado");
				}
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = (LightIntensity * -(MyTime / DurationLampe));
				}
			}
			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && Sceneswitch && Schlag) {
				MenschAnim.SetInteger ("State", 4);
				AudioObj.GetComponent<AudioSource> ().clip = Resources.Load<AudioClip> ("Schlag");
				AudioObj.GetComponent<AudioSource> ().Play ();
				Sceneswitch = false;
			}
		}
	
	}

	public void ElDoradoSceneUpdate (){
		//Debug.Log ("E: Update");

		if (Go) {
			if (Collides == true) {
				FlareIsShown = true;
				Flare.GetComponent<LensFlare> ().fadeSpeed = 0;
			}
			if (MyTime < DurationLampe) {
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = LightIntensity * (MyTime / DurationLampe);
				}
			} else {
				Go = false;
				Debug.Log ("Light On! Go: " + Go);
			}
		} else {

			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false  && !Sceneswitch) {
				if (Schlag) {
					Flare.GetComponent<Light> ().intensity = 0f;
					for (int i = 0; i < Lights.Length; i++) {
						Lights [i].GetComponent<Light> ().intensity = 0;
					}
					SaveVariable.SceneChange ("Fluss");
				}
				if (!HeadTrack) {
					Debug.Log ("count: " + countAudio);
					MenschAnim.SetInteger ("State", 5);
					loadClipIntoAudio (countAudio.ToString ());
					AudioObj.GetComponent<AudioSource> ().Play ();
					HeadTrack = true;
					MyTime = 0;
				} else if(!HeadTrackTime){
					MenschAnim.SetInteger ("State", 0);
					Kamera.GetComponent<Nodding> ().ActivateHeadMovement ();
					HeadTrackTime = true;
					MyTimeHEad = 0f;
					MyTime = 0;
				} 
			}

			if (MyTimeHEad > Kamera.GetComponent<Nodding> ().Duration && Kamera.GetComponent<Nodding> ().Auswertung == true) {
				Debug.Log ("Wahl: " + Kamera.GetComponent<Nodding> ().choice);
				switch (Kamera.GetComponent<Nodding> ().choice) {
				case -1:
					loadClipIntoAudio (countAudio.ToString () + "_O");
					SaveVariable.SetKooperation (-1);
					Schlag = true;
					break;
				case 0:
					loadClipIntoAudio (countAudio.ToString () + "_J");
					SaveVariable.SetKooperation (1);
					break;
				case 1:
					loadClipIntoAudio (countAudio.ToString () + "_N");
					SaveVariable.SetKooperation (-2);
					Schlag = true;
					break;
				}	
				countAudio++;
				AudioObj.GetComponent<AudioSource> ().Play ();
				HeadTrackTime = false;
				Sceneswitch = true;
				MyTimeHEad = 0;
			}
			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && Sceneswitch && !Schlag) {
				if (Lights [0].GetComponent<Light> ().intensity <= 0) {
					Flare.GetComponent<Light> ().intensity = 0f;
					SaveVariable.SceneChange ("Fluss");
				}
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].GetComponent<Light> ().intensity = (LightIntensity * -(MyTime / DurationLampe));
				}
			}
			if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && Sceneswitch && Schlag) {
				MenschAnim.SetInteger ("State", 4);
				AudioObj.GetComponent<AudioSource> ().clip = Resources.Load<AudioClip> ("Schlag");
				AudioObj.GetComponent<AudioSource> ().Play ();
				Sceneswitch = false;
			}
		}


	}

	public void FlussSceneUpdate (){
		//Debug.Log ("F: Update");

		if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && !Sceneswitch) {
			AudioObj.GetComponent<AudioSource> ().clip = Resources.Load<AudioClip> ("Text_Inter/5");
			AudioObj.GetComponent<AudioSource> ().Play ();
			Sceneswitch = true;
		}
		if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && Sceneswitch && !Schlag) {
			Schlag = true;
			Explosion.SetActive (true);
			AudioObj.GetComponent<AudioSource> ().clip = Resources.Load<AudioClip> ("gunshot");
			AudioObj.GetComponent<AudioSource> ().Play ();
		}
		if (AudioObj.GetComponent<AudioSource> ().isPlaying == false && Sceneswitch && Schlag) {
			SaveVariable.SceneChange ("Limbus");
		}
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

