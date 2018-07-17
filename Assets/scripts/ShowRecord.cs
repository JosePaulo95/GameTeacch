using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRecord : MonoBehaviour {


	// Use this for initialization
	void Start () {
		string a = "";
		int id_atual = PlayerPrefs.GetInt ("id_atual");
		int j;
		int lim = 200;
		Debug.Log (id_atual);
		for (int i = 0; i <= lim; i++) {
			j = id_atual - lim + i;
			if(j >= 0){
				a += (i)+". "+ Record.getRecord (j);
				a += "\n";
			}
		}
		GetComponent<Text> ().text = a;
	}
	public void chaveSalvar(){
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
