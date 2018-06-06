using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour {
	public int id_;
	private bool selected, foi_dropado_certo_=false;
	private float OffsetX, OffsetY;
	private Vector3 initial_pos_, drop_pos_;
	private Vector2 last_mouse_pos;
	private enum DropState{CERTO, ERRADO, FORA};
	private DropState estado_drop = DropState.FORA;

	// Use this for initialization
	void Start () {
		initial_pos_ = transform.position;
		if (GetComponent<BoxCollider2D> ()) {
			//GetComponent<BoxCollider2D> ().size = new Vector2(Config.getMargemErro(), Config.getMargemErro());
		}
	}

	// Update is called once per frame
	void Update(){
		if (selected == true){
			Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//transform.LookAt (new Vector3(cursorPos.x, cursorPos.y, 0));
			transform.position = new Vector2(cursorPos.x, cursorPos.y);
			//last_mouse_pos = cursorPos;
		}
		if (Input.GetMouseButtonUp(0)){
			selected = false;
		}
	}

	public void OnMouseOver(){
		if (Input.GetMouseButtonDown(0)){
			selected = true;
		}
	}

	public void BegingDrag(){
		if (!foi_dropado_certo_) {
			OffsetX = transform.position.x - Input.mousePosition.x;
			OffsetY = transform.position.y - Input.mousePosition.y;
		}
	}

	public void OnDrag(){
		if (!foi_dropado_certo_) {
			transform.position = new Vector2 (OffsetX + Input.mousePosition.x, OffsetY + Input.mousePosition.y);
		}
	}
	public void OnEndDrag(){
		if (!foi_dropado_certo_) {
			if (estado_drop == DropState.CERTO) {
				transform.position = drop_pos_;
				foi_dropado_certo_ = true;
				transform.parent.GetComponent<LvlProgress> ().notifyDropCerto ();
			} else {
				transform.position = initial_pos_;	
			}
		}
	}
	public void _entrouDropPoint(bool ehPtoAdequado, Vector3 drop_point_pos){
		if (ehPtoAdequado) {
			estado_drop = DropState.CERTO;
			drop_pos_ = drop_point_pos;
		} else {
			estado_drop = DropState.ERRADO;
		}
	}
	public void _saiuDropPoint(){
		estado_drop = DropState.FORA;
	}
}