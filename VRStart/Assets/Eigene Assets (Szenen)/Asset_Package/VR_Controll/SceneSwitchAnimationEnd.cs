// Script wird am Ende der BladeRunner Szene und ElDorado Szene verwendet. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitchAnimationEnd : MonoBehaviour {
	
	public string scenename = "Fluss";
	protected float MyTime = 0f;
	protected float AnimationLength = 60f;
	
	protected Animator m_Animator;
	AnimatorClipInfo[] m_CurrentClipInfo;
	
	protected bool ResetMytime = false;
	
	public GameObject AnimationObject;

	public void Start(){
		SetAnimationLength();
	}
	
	
	public void Update()
	{		
			SaveVariable.CountTime ();
			MyTime += Time.deltaTime;
			if (MyTime > m_CurrentClipInfo[0].clip.length)
			{
				SaveVariable.SceneChange (scenename);
			}
	}
	
	void SetAnimationLength(){
		m_Animator = AnimationObject.GetComponent<Animator>();
		m_CurrentClipInfo = this.m_Animator.GetCurrentAnimatorClipInfo(0);
		AnimationLength = m_CurrentClipInfo[0].clip.length;

		ResetMytime=false;
	}
	
	public void ChangeAnimObj(GameObject NeuesAnimationObjekt){
			AnimationObject = NeuesAnimationObjekt;
			SetAnimationLength();
	}
}