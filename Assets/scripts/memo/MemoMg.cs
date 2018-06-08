using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoMg : MonoBehaviour {
	private Card carta_anterior;
	private int count = 0;
	private int qtde_certos_ = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void click(Card c){
		if (count % 2 == 0) {
			carta_anterior = c;
		} else {
			if (c.id != carta_anterior.id) {
				c.vira ();
				carta_anterior.vira ();
			} else {
				qtde_certos_++;
				if (qtde_certos_ == 3) {
					Invoke ("mostraVitoria",0.3f);
				}
			}
		}
		count++;
	}
	private void mostraVitoria(){
		GameObject.Find ("win menu aux").transform.GetChild(1).gameObject.SetActive (true);
	}
}
