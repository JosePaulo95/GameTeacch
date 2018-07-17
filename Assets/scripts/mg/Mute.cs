using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {

	// Use this for initialization
	void Start () {
		muteNow (!Config.getEstaMscAtivada ());
	}
	public void muteNow(bool b){
		AudioSource a = GetComponent<AudioSource> ();
		if (a) {
			a.mute = b;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
