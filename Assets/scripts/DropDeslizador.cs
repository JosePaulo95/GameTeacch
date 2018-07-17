using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDeslizador : MonoBehaviour {
	private Vector3 alvo_pos_;
	private int passo;
	private bool indo;

	void Awake(){
		indo = false;
		passo = 4;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (indo) {
			transform.Translate ((alvo_pos_-transform.position)/passo);
			passo--;
			if (passo == 0) {
				//CancelInvoke ("go");
				indo = false;
				GetComponent<DragDrop> ().coisasPosDeslize ();
			}	
		}
	}
	public void deslize(Vector3 drop_pos_){
		alvo_pos_ = drop_pos_;
		indo = true;
		//InvokeRepeating ("go",0,0.01f);
	}
	private void go(){
		transform.Translate ((alvo_pos_-transform.position)/passo);
		passo--;
		if (passo == 0) {
		//	CancelInvoke ("go");
		}
	}
}
