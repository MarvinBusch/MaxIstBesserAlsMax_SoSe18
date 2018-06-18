using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodding : MonoBehaviour {

	private Vector3[] angles;
	private int index;
	private Vector3 centerAngle;
	bool ActivateHead;
	float myTime;
	public int choice;
	public int Duration = 5;

	// Use this for initialization
	void Start () {
		ResetGesture ();
		ActivateHead = false;
		myTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (ActivateHead) {
			myTime += Time.deltaTime;
			angles [index] = transform.eulerAngles;
			index++;
			if (index == 60*Duration) {
				CheckMovement ();
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
				ResetGesture ();
				ActivateHead = false;
				myTime = 0f;
			}
		}
	}

	public void CheckMovement(){
		bool right = false, left = false, up = false, down = false;
		if (choice == -1) {
			for (int i = 0; i < 60 * Duration; i++) {
				//if (angles [i].x < 275) {
				if ((centerAngle.x >= 20 && centerAngle.x < 85) || (centerAngle.x < 340 && centerAngle.x >= 275)) {
					if ((angles [i].x < centerAngle.x - 20) && !up) {
						up = true;
						Debug.Log ("Up: " + i + " Y: " + angles [i].y + " - Center: " + centerAngle.y + " | X: " + angles [i].x + " - Center: " + centerAngle.x);
					} else if (angles [i].x > centerAngle.x + 20 && !down) {
						down = true; 
						Debug.Log ("Down: " + i + " Y: " + angles [i].y + " - Center: " + centerAngle.y + " | X: " + angles [i].x + " - Center: " + centerAngle.x);
					}
				} else if (centerAngle.x >= 340) {
					if (angles [i].x < centerAngle.x - 20 && angles [i].x > 275 && !up) {
						up = true;
						Debug.Log ("Up(>340): " + i + " Y: " + angles [i].y + " - Center: " + centerAngle.y + " | X: " + angles [i].x + " - Center: " + centerAngle.x);
					} else if (angles [i].x > -360 + (centerAngle.x + 20) && angles [i].x < 85 && !down) {
						down = true; 
						Debug.Log ("Down(>340): " + i + " Y: " + angles [i].y + " - Center: " + centerAngle.y + " | X: " + angles [i].x + " - Center: " + centerAngle.x);
					}
				} else if (centerAngle.x < 20) {
					if (angles [i].x > centerAngle.x + 20 && angles [i].x < 85 && !down) {
						down = true;
						Debug.Log ("Down(<20): " + i + " Y: " + angles [i].y + " - Center: " + centerAngle.y + " | X: " + angles [i].x + " - Center: " + centerAngle.x);
					} else if (angles [i].x < 360 + (centerAngle.x - 20) && angles [i].x > 275 && !up) {
						up = true; 
						Debug.Log ("Down(<20): " + i + " Y: " + angles [i].y + " - Center: " + centerAngle.y + " | X: " + angles [i].x + " - Center: " + centerAngle.x);
					}
				}

				if (angles [i].y < centerAngle.y - 20.0f && !left) {
					left = true; Debug.Log ("Left: " + i + " Y: " + angles [i].y + " - Center: " + centerAngle.y + " | X: " + angles [i].x + " - Center: " + centerAngle.x);
				} else if (angles [i].y > centerAngle.y + 20.0f && !right) {
					right = true;Debug.Log ("Right: " + i + " Y: " + angles [i].y + " - Center: " + centerAngle.y + " | X: " + angles [i].x + " - Center: " + centerAngle.x);
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
	}

	public void ActivateHeadMovement(){
		ActivateHead = true;
		ResetGesture ();
		Debug.Log ("Start Headtracking");
	}
}


