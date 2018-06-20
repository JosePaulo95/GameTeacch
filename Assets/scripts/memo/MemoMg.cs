using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoMg : MonoBehaviour {
	private Card carta_anterior;
	private int count = 0;
	private int qtde_certos_ = 0;
	public LvlProgress refLvlProgress;

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
				refLvlProgress.notifyErro ();
				c.vira ();
				carta_anterior.vira ();
			} else {
				qtde_certos_++;
				refLvlProgress.notifyDropCerto ();
				refLvlProgress.notifyDropCerto ();
			}
		}
		count++;
	}
}
