using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

	public float fadeSpeed = 0.2f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private float fadeDir = -1.0f;
	private Color NewColor;
	private float FadingIn;

	void Start(){
		NewColor = new Color (0f,0f,0f,1);	
		GetComponent<Renderer> ().material.SetColor ("_Color", NewColor);
	}

	void Update(){
		
		if (alpha <= 1 || alpha >= 0) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);
			NewColor = new Color (0f, 0f, 0f, alpha);
			GetComponent<Renderer> ().material.SetColor ("_Color", NewColor);
		}
	}

	public void BeginFadeIng (float directionIn) {
		if (alpha<=0){fadeDir = directionIn;}
	}

	public void BeginFadeOut (float directionOut) {
		fadeDir = directionOut;
	}

	void OnLevelWasLoaded(){
		BeginFadeIng(-1);
	}
}
