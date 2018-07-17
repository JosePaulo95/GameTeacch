using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Record : MonoBehaviour {
	private int id_atual = 0;
	private static int qtde_erros = 0;
	// Use this for initialization
	void Awake () {
		id_atual = PlayerPrefs.GetInt ("id_atual");
		Debug.Log (id_atual);
	}
	void Start () {
		//if (Config.getEstaMscAtivada()) {
		//	GetComponent<AudioSource> ().Play ();
		//}
	}
	public void setaNvl(int nvl){
		id_atual++;
		PlayerPrefs.SetInt ("id_atual", id_atual);

		PlayerPrefs.SetInt(("Nvl"+id_atual), nvl);
		PlayerPrefs.SetString(("Data"+id_atual), System.DateTime.Now.ToString("dd/MM/yyyy"));
		PlayerPrefs.SetString(("Hora"+id_atual), System.DateTime.Now.ToString("HH:mm"));
	}
	public void fim(float time_inicio){
		float d = (Time.time - time_inicio);
		int dur = (int)d;
		int sec = dur % 60;
		int min = (dur / 60) % 60;
		PlayerPrefs.SetString (("Duracao" + id_atual), min.ToString("D2")+":"+sec.ToString("D2"));

		PlayerPrefs.SetInt (("Erros" + id_atual), qtde_erros);
		qtde_erros = 0;
	}
	public void setaAtv(int atv){
		PlayerPrefs.SetInt(("Atv"+id_atual), atv);
	}
	public void addErro(){
		qtde_erros++;
		Debug.Log ("erro = " + qtde_erros);
	}
	public static string getRecord(int id){
		//int id = PlayerPrefs.GetInt ("id_atual");
		string data = PlayerPrefs.GetString("Data"+id);
		string hora = PlayerPrefs.GetString("Hora"+id);
		int nvl = PlayerPrefs.GetInt ("Nvl" + id);
		int atv = PlayerPrefs.GetInt ("Atv" + id);
		int erros = PlayerPrefs.GetInt ("Erros" + id);
		string duracao = PlayerPrefs.GetString ("Duracao" + id);
		return data+" | "+hora+" | "+nvl+" | "+atv+" | "+erros+" | "+duracao;
	} 
	// Update is called once per frame
	void Update () {
		
	}
}
