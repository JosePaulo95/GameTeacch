using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	public Sprite img1, img2;
	public MemoMg refMemoMg;
	public int id;
	private bool face_para_baixo = true;
	// Use this for initialization
	void Start () {
		GetComponent<Image> ().sprite = img1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void vira(){
		Invoke ("viraAux", 0.5f);
	}
	private void viraAux(){
		face_para_baixo = true;
		GetComponent<Button> ().enabled = true;
		GetComponent<Image> ().sprite = img1;
	}
	public void click(){
		if (face_para_baixo) {
			refMemoMg.click (this);
			if (face_para_baixo) {
				face_para_baixo = false;
				GetComponent<Button> ().enabled = false;
				GetComponent<Image> ().sprite = img2;	
			}
		}
	}
}
