using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Das Script wird benutzt um die Kopfbewegung und damit die Entscheidung zu überprüfen.
public class Nodding : MonoBehaviour {

	private Vector3[] angles;
	private int index;
	private Vector3 centerAngle;
	bool ActivateHead;
	public bool Auswertung;
	float myTime;
	public int choice;
	public int Duration = 5;

	// Use this for initialization
	void Start () {
		ResetGesture ();
		ActivateHead = false;
		Auswertung = false;
		myTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (ActivateHead) {									// Wenn eine Entscheidung gefordert ist:
			myTime += Time.deltaTime;						
			angles [index] = transform.eulerAngles;			// pro Frame wird die aktuelle Position der Kamera in einen Array gespeichert
			index++;										// (Das Script liegt auf der Kamera.)

			if (index == 60 * Duration) {					// Wenn eine Bestimmte Anzahl an Frames getrackt wurden.
				
				CheckMovement ();							// Prüft, was ausgewählt wurde.
				switch (choice) {
				case 0:
					print ("Response = Yes");
					break;
				case 1:
					print ("Response = No");
					break;
				case -1:
					print ("Response = No decision");
					break;
				default:
					break;
				}
				ActivateHead = false;
				Auswertung = true;
				myTime = 0f;
			}
		}
	}

	// Nicken oder Schütteln wird geprüft.
	public void CheckMovement(){
		bool right = false, left = false, up = false, down = false;

		if (choice == -1) {
			for (int i = 0; i < 60 * Duration; i++) {
				//if (angles [i].x < 275) {
				if ((centerAngle.x >= 20 && centerAngle.x < 85) || (centerAngle.x < 340 && centerAngle.x >= 275)) {
					if ((angles [i].x < centerAngle.x - 20) && !up) {
						up = true;
					} else if (angles [i].x > centerAngle.x + 20 && !down) {
						down = true; 
					}
				} else if (centerAngle.x >= 340) {
					if (angles [i].x < centerAngle.x - 20 && angles [i].x > 275 && !up) {
						up = true;
					} else if (angles [i].x > -360 + (centerAngle.x + 20) && angles [i].x < 85 && !down) {
						down = true; 
					}
				} else if (centerAngle.x < 20) {
					if (angles [i].x > centerAngle.x + 20 && angles [i].x < 85 && !down) {
						down = true;
					} else if (angles [i].x < 360 + (centerAngle.x - 20) && angles [i].x > 275 && !up) {
						up = true; 
					}
				}

				if (angles [i].y < centerAngle.y - 20.0f && !left) {
					left = true; 
				} else if (angles [i].y > centerAngle.y + 20.0f && !right) {
					right = true;
				}
			}
		}

		Debug.Log ("L: " + left + " | R: " + right + " | U: " + up + " | D: " + down);

		if (left && right && !(up && down)) {
			choice = 1;
		}
		if (up && down && !(left && right)) {
			choice = 0;
		}
	}

	void ResetGesture(){
		angles = new Vector3[60*Duration];
		index = 0;
		centerAngle = transform.eulerAngles;
		choice = -1;
		Auswertung = false;
	}

	public void ActivateHeadMovement(){
		ActivateHead = true;
		ResetGesture ();
		Debug.Log ("Start Headtracking");
	}
}


