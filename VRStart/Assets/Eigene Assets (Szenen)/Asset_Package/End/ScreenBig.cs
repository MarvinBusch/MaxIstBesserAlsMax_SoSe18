using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class ScreenBig : MonoBehaviour {

	public float MyTime = 0f;

	public float MultiplierScale = 1.42f;
	public float MultiplierPosition = 0.7f;
	
	public float Duration = 1f;
	
	private bool lookAt = false;
	private bool countMytime = false;
	
	protected float LocalScaleX;
	protected float LocalScaleY;
	protected float LocalScaleZ;
	
	protected float LocalPositionX;
	protected float LocalPositionY;
	protected float LocalPositionZ;

	public GameObject VideoObj;
	
	// Use this for initialization
	void Start () {
		lookAt=false;
		countMytime=false;
		MyTime=0;
		LocalScaleX =transform.localScale.x;
		LocalScaleY =transform.localScale.y;
		LocalScaleZ =transform.localScale.z;
		LocalPositionX =transform.localPosition.x;
		LocalPositionY =transform.localPosition.y;
		LocalPositionZ =transform.localPosition.z;
		VideoObj.GetComponent<VideoPlayer> ().frame = 2;
		VideoObj.GetComponent<VideoPlayer> ().Play();
		VideoObj.GetComponent<VideoPlayer> ().Pause();
	}
	// Update is called once per frame
	void Update () {
		MyTime += Time.deltaTime;
		
		if(lookAt==true){
			//if(transform.localScale.x < LocalScaleX * MultiplierScale){
					transform.localScale = new Vector3(LocalScaleX * MultiplierScale, LocalScaleY * MultiplierScale, LocalScaleZ * MultiplierScale);
					transform.localPosition = new Vector3(LocalPositionX * MultiplierPosition, LocalPositionY * MultiplierPosition, LocalPositionZ * MultiplierPosition);
			//}
			//else countMytime=false;

		}
		else{
			if(transform.localScale.x > LocalScaleX){
					transform.localScale = new Vector3(transform.localScale.x * (1/MultiplierScale), transform.localScale.y * (1/MultiplierScale), transform.localScale.z * (1/MultiplierScale));
					transform.localPosition = new Vector3(transform.localPosition.x * (1/MultiplierPosition), transform.localPosition.y * (1/MultiplierPosition), transform.localPosition.z * (1/MultiplierPosition));
			}
			else countMytime=false;
		}
	}

	public void ScreenLookAt(){
		lookAt=true;
		countMytime=true;
		MyTime=0;
	}
	public void ScreenDontLookAt(){
		lookAt=false;
		countMytime=true;
		MyTime=0;
	}

	public void PlayVideo (){
		VideoObj.GetComponent<VideoPlayer>().Play();
	}

	public void StopVideo (){
		VideoObj.GetComponent<VideoPlayer>().Pause();
	}
}
