using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielManager : MonoBehaviour {

	bool tod = true;
	int Leben = 3;
	Vector3 KugelPos;

	public GameObject Kugel;
	public GameObject Text;

	// Use this for initialization
	void Start () {
		Leben = (SaveVariable.kooperation/2 + 3);

		Text.GetComponent<TextMesh>().text = "Es sind noch " + Leben.ToString() + " Versuche über";
		KugelPos = Kugel.GetComponent<Transform> ().position;
		Kugel.GetComponent<Rigidbody> ().isKinematic = true;
		Kugel.GetComponent<Renderer> ().enabled = false;
		RenderSettings.skybox.SetFloat("_Exposure", 1f);
		RenderSettings.skybox.SetColor("_Tint", Color.gray);
	}

	void Update(){
		SaveVariable.CountTime ();
	}

	void OnTriggerEnter(Collider other){
		Kugel.GetComponent<Rigidbody> ().isKinematic = true;
		Kugel.GetComponent<SphereCollider> ().enabled = false;
		Kugel.GetComponent<Transform> ().position = KugelPos;
		Kugel.GetComponent<Rigidbody> ().drag = Kugel.GetComponent<Kugelschneller> ().startDrag;
		Verlust ();
	}

	public void Verlust(){

		if (Leben <= 1) {
			SaveVariable.SceneChange ("Limbus");
		} else {
			Leben = Leben - 1;
			tod = true;
			Text.GetComponent<TextMesh> ().text = "Es sind noch " + Leben.ToString () + " Versuche über";
			RenderSettings.skybox.SetFloat ("_Exposure", RenderSettings.skybox.GetFloat ("_Exposure") - 0.15f);
			RenderSettings.skybox.SetColor ("_Tint", new Color (RenderSettings.skybox.GetColor ("_Tint").r, RenderSettings.skybox.GetColor ("_Tint").g - 0.1f, RenderSettings.skybox.GetColor ("_Tint").b - 0.15f));
		}
	}

	public void NeueRunde(){
		if(tod){
			Kugel.GetComponent<Rigidbody> ().isKinematic = false;
			Kugel.GetComponent<SphereCollider> ().enabled = true;
			Kugel.GetComponent<Renderer> ().enabled = true;
			tod = false;
			//Kugel.GetComponent<Renderer> ().enabled = true;
		}

	}
}