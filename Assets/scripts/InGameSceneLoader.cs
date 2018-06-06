using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void proximaFase(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void menuFases(){
		SceneManager.LoadScene("MenuFases");
	}
}
