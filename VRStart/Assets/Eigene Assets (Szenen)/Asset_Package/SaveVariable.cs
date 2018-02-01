using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVariable : MonoBehaviour {

	static public bool Utopie;
	
	public void Start(){
		Utopie = true;
	}
	
	public void SetUtopieTrue(){Utopie=true;}
	public void SetUtopieFalse(){Utopie=false;}
	
}
