using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {
	private static float margem_erro = 70;
	private static bool esta_msc_ativada_;

	// Use this for initialization
	void Awake () {
		checaChaveMsc ();
	}

	public static void checaChaveMsc(){
		if (PlayerPrefs.GetString ("msc") == "off") {
			esta_msc_ativada_ = false;
		} else {
			esta_msc_ativada_ = true;
		}
	}

	public static bool getEstaMscAtivada(){
		checaChaveMsc ();
		return esta_msc_ativada_;
	}
	public static void desligaMsc(){
		esta_msc_ativada_ = false;
		PlayerPrefs.SetString ("msc", "off");
	}
	public static void ligaMsc(){
		esta_msc_ativada_ = true;
		PlayerPrefs.SetString ("msc", "on");
	}
	public void desligaMscI(){
		esta_msc_ativada_ = false;
		PlayerPrefs.SetString ("msc", "off");
	}
}
