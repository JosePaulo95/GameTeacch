using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRecord : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string a = Record.getRecord ();
		GetComponent<Text> ().text = a;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
