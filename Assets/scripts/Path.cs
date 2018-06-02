using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collision){
		DragDropCar drag = collision.GetComponent<DragDropCar> ();
		if (drag != null) {
			drag.barreira ();
		}
	}
	void OnTriggerStay2D(Collider2D collision){
		DragDropCar drag = collision.GetComponent<DragDropCar> ();
		if (drag != null) {
			drag.barreira();
		}
	}
}
