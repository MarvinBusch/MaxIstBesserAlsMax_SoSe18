using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_Interrogation_New : MonoBehaviour {

	protected float MyTime = 0f;
	public GameObject Flare;
	protected float brightness;
	protected bool AudioEnded=false;
	public GameObject Türe;
	public GameObject Lampe;

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

	public GameObject Audio;

	private bool TuereAuf = false;
	private bool StartTuere = false;




	private bool EndTuere=false;
	private bool Go = false;
	private bool end = false;
	private bool FlareIsShown = false;
	private bool Collides = false;
	private bool AudioPlay = false;



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
			case "BladeRunner":
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

		MyTime=0f;

		/*for(int i=0; i<Lights.Length; i++){
			Lights[i].GetComponent<Light>().intensity = 0f;
		}*/

		MenschAnim = MenschTisch.GetComponent<Animator>();
		MenschTisch.SetActive (false);
		TuereAuf = false;
		StartTuere = false;
	}

	public void ElDoradoSceneSetup (){
		Debug.Log ("E: "+SaveVariable.letzteSzene);
	}

	public void MatrixSceneSetup (){
		Debug.Log ("M: "+SaveVariable.letzteSzene);
	}

	public void FlussSceneSetup (){
		Debug.Log ("F: "+SaveVariable.letzteSzene);
	}

	// Update is called once per frame
	void Update () {
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
			case "BladeRunner":
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
		if (EndTuere==false)
		{
			MyTime += Time.deltaTime;

			if(MyTime>WaitTime&&StartTuere==false){
				MyTime=0;
				StartTuere=true;
				MenschTisch.SetActive (true);
				MenschAnim.SetInteger ("State", 1);
			}
			if(MyTime>DurationTuere&&StartTuere==true){
				EndTuere=true;
				Türe.GetComponent<Transform>().eulerAngles = new Vector3(-90, 0, 90);
				MyTime=0;
				MenschAnim.SetInteger ("State", 0);
			}		
			if(StartTuere==true)
			{
				if(TuereAuf == false){
					if(MyTime>(DurationTuere/2)){TuereAuf=true;}
					else{Türe.GetComponent<Transform>().eulerAngles = new Vector3 (-90, 0, 90 + (90 * (MyTime/(DurationTuere/2))));}
				}
				if(TuereAuf == true){
					Türe.GetComponent<Transform>().eulerAngles = new Vector3(-90, 0, 270 + (-90 * (MyTime/(DurationTuere/2))));
				}
			}
		}
		else{		
			Türe.GetComponent<Transform>().eulerAngles = new Vector3(-90, 0, 90);
			if(FlareIsShown==true)
			{
				Flare.GetComponent<LensFlare>().fadeSpeed = 0;
			}
			if(end==false){
				MyTime += Time.deltaTime;
				if(MyTime>WaitTime&&Go==false){
					Lampe.GetComponent<AudioSource>().Play();
					MyTime=0;
					Go=true;
					Flare.GetComponent<Light>().intensity = FlareIntensity;
					Flare.GetComponent<LensFlare>().brightness = FlareBrightness;
					if(Collides==true) {FlareIsShown = true;}
				}
				if(MyTime>DurationLampe&&Go==true){
					end=true;
				}
				if(Go==true){
					for(int i=0; i<Lights.Length; i++){
						Lights[i].GetComponent<Light>().intensity = LightIntensity * (MyTime/DurationLampe);
					}
				}
		}
		if (end==true){
			if(AudioPlay==false){
				Audio.GetComponent<AudioSource>().Play();
				MyTime=0;
				MenschAnim.SetInteger ("State", 2);
				AudioPlay=true;
			}
			//else{MyTime+= Time.deltaTime;}
			//if (MyTime>3f){MenschAnim.enabled = false;}
			//if (MyTime>Audio.GetComponent<AudioSource>().clip.length - 1f){MenschAnim.enabled = true; MenschAnim.speed = 2.5f;}
			//if(MyTime>Audio.GetComponent<AudioSource>().clip.length){SaveVariable.SceneChange ("Matrix");}
		}

		}
	}

	public void ElDoradoSceneUpdate (){
		Debug.Log ("E: Update");
	}

	public void MatrixSceneUpdate (){
		Debug.Log ("M: Update");
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

}

