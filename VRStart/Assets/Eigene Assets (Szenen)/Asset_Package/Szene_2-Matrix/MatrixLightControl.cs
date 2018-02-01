using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixLightControl : MonoBehaviour {

	public float StartTime = 5.0f;
	public float Duration = 10.0f;
	protected float MyTime = 0f;

	public Transform[] Lights;
	public float LightIntensity = 1f;

	public Transform Türe;
	public float LightIntensityTüre = 1f;

	public Transform Raum;
	public GameObject Hände;
	public ParticleSystem MatrixRegen;
	//public GameObject Hand_D;
	//public GameObject Hand_U;
	public GameObject Pille_D;
	public GameObject Pille_U;


	private bool Go = false;
	private bool end = false;

	// Use this for initialization
	void Start () {
		Go=false;
		end=false;	
		MyTime=0f;
		for(int i=0; i<Lights.Length; i++){
			Lights[i].GetComponent<Light>().intensity = 0f;
		}	
		Türe.GetComponent<Light>().intensity = 0f;
		Hände.SetActive(false);
		/*Hand_U.GetComponent<Renderer>().material.color = new Color (Hand_U.GetComponent<Renderer>().material.color.r, Hand_U.GetComponent<Renderer>().material.color.g, Hand_U.GetComponent<Renderer>().material.color.b, 0);
		Hand_D.GetComponent<Renderer> ().material.color = new Color (Hand_D.GetComponent<Renderer>().material.color.r, Hand_D.GetComponent<Renderer>().material.color.g, Hand_D.GetComponent<Renderer>().material.color.b, 0);
		Pille_U.GetComponent<Renderer>().material.color = new Color (Pille_U.GetComponent<Renderer>().material.color.r, Pille_U.GetComponent<Renderer>().material.color.g, Pille_U.GetComponent<Renderer>().material.color.b, 0);
		Pille_D.GetComponent<Renderer> ().material.color = new Color (Pille_D.GetComponent<Renderer>().material.color.r, Pille_D.GetComponent<Renderer>().material.color.g, Pille_D.GetComponent<Renderer>().material.color.b, 0);
		*/ //Raum.transform.localScale += new Vector3(0, 0, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if(end==false){
			MyTime += Time.deltaTime;
			if(MyTime>StartTime&&Go==false){
				MyTime=0;
				Hände.SetActive(true);
				Go=true;
				Hände.GetComponent<Animator>().SetBool("PlayBool", true);
				//Pille_D.GetComponent<Animator>().SetBool("PlayBool", true);
				//Pille_U.GetComponent<Animator>().SetBool("PlayBool", true);				
				//Raum.transform.localScale += new Vector3(0, 0, -5);
				//MatrixRegen.Stop();
			}
			if(MyTime>Duration&&Go==true){
				end=true;
			}
			if(Go==true){
				for(int i=0; i<Lights.Length; i++){
					Lights[i].GetComponent<Light>().intensity = LightIntensity * (MyTime/Duration);
				}
				Türe.GetComponent<Light>().intensity = LightIntensityTüre * (MyTime/Duration);

				/*Hand_U.GetComponent<Renderer>().material.color = new Color (Hand_U.GetComponent<Renderer>().material.color.r, Hand_U.GetComponent<Renderer>().material.color.g, Hand_U.GetComponent<Renderer>().material.color.b, 1 * (MyTime/Duration));
				Hand_D.GetComponent<Renderer> ().material.color = new Color (Hand_D.GetComponent<Renderer>().material.color.r, Hand_D.GetComponent<Renderer>().material.color.g, Hand_D.GetComponent<Renderer>().material.color.b, 1 * (MyTime/Duration));
				Pille_U.GetComponent<Renderer>().material.color = new Color (Pille_U.GetComponent<Renderer>().material.color.r, Pille_U.GetComponent<Renderer>().material.color.g, Pille_U.GetComponent<Renderer>().material.color.b, 0);
				Pille_D.GetComponent<Renderer> ().material.color = new Color (Pille_D.GetComponent<Renderer>().material.color.r, Pille_D.GetComponent<Renderer>().material.color.g, Pille_D.GetComponent<Renderer>().material.color.b, 0);
			*/}
		}
		
	}
}
