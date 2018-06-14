using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRecord : MonoBehaviour {


	// Use this for initialization
	void Start () {
		string a = "";
		int id_atual = PlayerPrefs.GetInt ("id_atual");
		for (int i = 0; i <= id_atual; i++) {
			a += (i+1)+". "+ Record.getRecord (i);
			a += "\n";
		}
		GetComponent<Text> ().text = a;
	}
	public void chaveSalvar(){
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
