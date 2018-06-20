using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhaChegada : MonoBehaviour {
	public LvlProgress refLevelProgress;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collision){
		DragDropCar drag = collision.GetComponent<DragDropCar> ();
		if (drag != null) {
			refLevelProgress.notifyDropCerto ();
			drag._entrouDropPoint (true, transform.position);
		}
	}
}
