using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlProgress : MonoBehaviour {
	private int qtde_certos_;
	private int qtde_drops_total_;

	// Use this for initialization
	void Start () {
		qtde_drops_total_ = transform.childCount;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void notifyDropCerto(){
		qtde_certos_++;

		if (qtde_certos_ == qtde_drops_total_) {
			Debug.Log ("sucesso");
			Invoke ("mostraVitoria",0.3f);
		}
	}
	private void mostraVitoria(){
		GameObject.Find ("win menu aux").transform.GetChild(1).gameObject.SetActive (true);
	}
}
