using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlProgress : MonoBehaviour {
	private int qtde_certos_;
	private int qtde_drops_total_;
	public int nvl, atv;
	private Record refRecord;
	private float time_inicio;

	// Use this for initialization
	void Start () {
		refRecord = GameObject.Find ("win menu aux").GetComponent<Record> ();

		time_inicio = Time.time;

		qtde_drops_total_ = transform.childCount;	
		refRecord.setaNvl (nvl);
		refRecord.setaAtv (atv);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void notifyErro(){
		refRecord.addErro ();
	}
	public void notifyDropCerto(){
		qtde_certos_++;

		if (qtde_certos_ == qtde_drops_total_) {
			Debug.Log ("sucesso");
			Invoke ("mostraVitoria",0.3f);
		}
	}
	private void mostraVitoria(){
		//GameObject.Find ("win menu aux").transform.GetChild(1).gameObject.SetActive (true);
		GameObject.Find ("win menu aux").GetComponent<Animator>().SetTrigger("win");
		GameObject.Find ("win menu aux").GetComponent<AudioSource> ().Stop ();
		GameObject.Find ("win menu aux").transform.GetChild (1).GetComponent<AudioSource> ().Play ();
		refRecord.fim (time_inicio);
	}
}
