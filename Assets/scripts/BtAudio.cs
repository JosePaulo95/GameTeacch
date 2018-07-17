using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtAudio : MonoBehaviour {
	public Sprite on_, off_;
	public bool esta_ligado_;
	public Mute fonte_audio;

	void Awake(){
		esta_ligado_ = Config.getEstaMscAtivada ();
	}

	// Use this for initialization
	void Start () {
		if (esta_ligado_) {
			GetComponent<Image> ().sprite = on_;
		} else {
			GetComponent<Image> ().sprite = off_;
		}
	}
	public void change(){
		if (esta_ligado_) {
			fonte_audio.muteNow (true);
			Config.desligaMsc ();
			GetComponent<Image> ().sprite = off_;
		} else {
			fonte_audio.muteNow (false);
			Config.ligaMsc ();
			GetComponent<Image> ().sprite = on_;
		}
		esta_ligado_ = !esta_ligado_;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
