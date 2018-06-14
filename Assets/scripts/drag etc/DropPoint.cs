using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropPoint : MonoBehaviour {
	private Image area_, img_;
	public Color normal_color_, highlight_color_, error_color_;
	public Sprite img_normal_, img_correto_, img_errado_;
	public float margem_erro_;
	public int id_;

	// Use this for initialization
	void Start () {
		area_ = transform.GetChild (0).GetComponent<Image>();
		img_ = transform.GetChild (1).GetComponent<Image>();
		if (GetComponent<BoxCollider2D> ()) {
			//GetComponent<BoxCollider2D> ().size = new Vector2 (Config.getMargemErro (), Config.getMargemErro ());
		}
		//area_.sprite = img_normal_;
		//area_.color = normal_color_;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collision){
		DragDrop drag = collision.GetComponent<DragDrop> ();
		if (drag != null) {
			if (drag.id_ == id_) {
				drag._entrouDropPoint (true, transform.position);
				//area_.color = highlight_color_;		
				area_.sprite = img_correto_;
			} else {
				//drag._entrouDropPoint (false, transform.position);
				//area_.color = error_color_;
				area_.sprite = img_errado_;
			}
		}
	}
	void OnTriggerExit2D(Collider2D collision){
		area_.sprite = img_normal_;
		DragDrop drag = collision.GetComponent<DragDrop> ();
		if (drag != null) {
			if (drag.id_ == id_) {
				drag._saiuDropPoint ();
			}
		}
	}
}
