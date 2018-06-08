using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropPointRecipientes : MonoBehaviour {
	private Image area_, img_;
	public Color normal_color_, highlight_color_, error_color_;
	public float margem_erro_;
	public int id_;

	// Use this for initialization
	void Start () {
		area_ = transform.GetChild (0).GetComponent<Image>();
		img_ = transform.GetChild (1).GetComponent<Image>();
		if (GetComponent<BoxCollider2D> ()) {
			//GetComponent<BoxCollider2D> ().size = new Vector2 (Config.getMargemErro (), Config.getMargemErro ());
		}
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D collision){
		DragDropRecipientes drag = collision.GetComponent<DragDropRecipientes> ();
		if (drag != null) {
			if (drag.id_ == id_) {
				drag._entrouDropPoint (true, transform.position);
				area_.color = highlight_color_;		
			} else {
				//drag._entrouDropPoint (false, transform.position);
				area_.color = error_color_;
			}
		}
	}
	void OnTriggerExit2D(Collider2D collision){
		area_.color = normal_color_;
		DragDropRecipientes drag = collision.GetComponent<DragDropRecipientes> ();
		if (drag != null) {
			if (drag.id_ == id_) {
				drag._saiuDropPoint ();
			}
		}
	}
}
