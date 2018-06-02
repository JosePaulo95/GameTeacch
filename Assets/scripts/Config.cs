using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {
	private static float margem_erro = 70;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static float getMargemErro(){
		float size = 1.5f + margem_erro*1.5f;
		return size;
	}
}
