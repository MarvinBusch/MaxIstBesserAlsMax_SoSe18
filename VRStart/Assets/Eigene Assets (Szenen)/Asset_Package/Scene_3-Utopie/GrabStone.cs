using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabStone : MonoBehaviour {
	
	protected float MyTime = 0f;
	public GameObject Hand;

	public float PlaySpeed = 0.5f;
	public float InverseMultiplier = 5f;
	private bool AnimUnderZero = false;
	private bool AnimOverOne = false;
	private bool StoneGrabbing = false;

	public GameObject DropCollider;
	public GameObject GVRKontroller;
	public GameObject Kamera;
	public GameObject World;
	public GameObject[] Stone;
	int steinnummer;
	Transform tempTrans;


	public void Start()
	{
		Hand.GetComponent<Animator>().SetFloat("AnimationSpeed", 0);
		AnimUnderZero = false;
		StoneGrabbing = false;
		AnimOverOne = false;
		DropCollider.SetActive (false);
		GVRKontroller.SetActive (true);
		steinnummer = 0;
	}

	public void Update()
	{ 	
		if (Hand.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0 && !Hand.GetComponent<Animator>().IsInTransition(0)&&AnimUnderZero==true) {
			Hand.GetComponent<Animator>().SetFloat("AnimationSpeed", 0);
			AnimUnderZero = false;
		}

		if (Hand.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 0 && !Hand.GetComponent<Animator>().IsInTransition(0)){
			Hand.GetComponent<Animator>().SetFloat("AnimationSpeed", PlaySpeed);
			AnimUnderZero = true;
		}

		if (Hand.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !Hand.GetComponent<Animator>().IsInTransition(0)&&StoneGrabbing==false){
			TakeStone (steinnummer);
			StoneGrabbing = true;
			AnimOverOne = true;
		}

		if (Hand.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime < 1 && !Hand.GetComponent<Animator>().IsInTransition(0)&&AnimOverOne==true) {
			Hand.GetComponent<Animator>().SetFloat("AnimationSpeed", 0);
			AnimOverOne = false;
		}

	}
		
	public void LookAtAnimStart(int stein){
		steinnummer = stein;
		Hand.GetComponent<Animator>().SetFloat("AnimationSpeed", PlaySpeed);
	}

	public void LookNOTAtAnimStart(){
		Hand.GetComponent<Animator> ().SetFloat ("AnimationSpeed", -InverseMultiplier * PlaySpeed);
	}

		public void TakeStone(int x){
		Stone[x].transform.parent = Kamera.transform;
		DropCollider.SetActive (true);
		GVRKontroller.SetActive (false);
	}

	public void DropStone(){
		DropCollider.SetActive (false);
		GVRKontroller.SetActive (true);
		Stone[steinnummer].transform.parent = World.transform;
		MeshCollider[] colliders = Stone [steinnummer].GetComponents<MeshCollider> ();
		foreach (MeshCollider mc in colliders) {mc.enabled = false;}
		Stone[steinnummer].GetComponent<Rigidbody> ().isKinematic= true;
		LookNOTAtAnimStart ();
		StoneGrabbing = false;
	}
}

