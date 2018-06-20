using System.Collections;
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
	public void menuPrincipal(){
		SceneManager.LoadScene("MenuPrincipal");
	}
	public void menuOpcoes(){
		SceneManager.LoadScene("MenuOpcoes");
	}
	public void carregarFaseIndex(int index){
		index--;
		int[] lvls = new int[]{ 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19,20 };
		SceneManager.LoadScene(lvls[index]);
	}
	public void fecharJogo(){
		Application.Quit ();
	}
}
