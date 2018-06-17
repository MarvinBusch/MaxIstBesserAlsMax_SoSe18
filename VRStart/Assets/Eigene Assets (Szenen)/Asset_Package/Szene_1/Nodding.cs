using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodding : MonoBehaviour {

	private Vector3[] angles;
	private int index;
	private Vector3 centerAngle;
	bool ActivateHead;
	float myTime;
	public float Duration;

	// Use this for initialization
	void Start () {
		ResetGesture ();
		myTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (ActivateHead) {
			myTime += Time.deltaTime;
			angles [index] = transform.eulerAngles;
			index++;
			if (index == 60) {
				int choice = CheckMovement ();
				switch (choice) {
				case 0:
					break;
				case 1:
					print ("Response = Yes");
					break;
				case 2:
					print ("Response = No");
					break;
				case 3:
					print ("Response = No decision");
					break;
				default:
					break;
				}
				ResetGesture ();
				myTime = 0f;
			}
		}
	}

	public int CheckMovement(){
		bool right = false, left = false, up = false, down = false;
		for (int i = 0; i < 60; i++) {
			if (angles [i].x > centerAngle.x - 20.0f && !up) {
				up = true;
			}else if(angles [i].x > centerAngle.x + 20.0f && !down){
				down = true;
			}

			if (angles [i].y > centerAngle.y - 20.0f && !left) {
				left = true;
			}else if(angles [i].y > centerAngle.y + 20.0f && !right){
				right = true;
			}
		}

		if (left && right && !(up && down)) {
			return 2;
		}
		if (up && down && !(left && right)) {
			return 1;
		}
		if (myTime > Duration) {return 3;}
		return 0;
	}

	void ResetGesture(){
		angles = new Vector3[60];
		index = 0;
		centerAngle = transform.eulerAngles;
		ActivateHead = false;
	}

	public void ActivateHeadMovement(){
		ActivateHead = true;
		Debug.Log ("Start Headtracking");
	}
}


