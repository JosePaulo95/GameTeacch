﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void jogar(){
		SceneManager.LoadScene("MenuFases");
	}
	public void carregarFaseIndex(int index){
		SceneManager.LoadScene(index);
	}
}