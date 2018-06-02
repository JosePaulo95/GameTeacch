using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDropCar : MonoBehaviour {
	public int id_;
	private bool selected, foi_dropado_certo_=false, bateu_barreira_ = false;
	private float OffsetX, OffsetY, target_angle, lerp_rotation=0;
	private Vector3 initial_pos_, drop_pos_, last_mouse_distant_pos;
	private Vector3 last_safe_pos_;
	private Quaternion last_safe_rotation_;
	private Vector2 last_mouse_pos;
	private enum DropState{CERTO, ERRADO, FORA};
	private DropState estado_drop = DropState.FORA;

	// Use this for initialization
	void Start () {
		initial_pos_ = transform.position;

		atualizaSafe ();

		GetComponent<BoxCollider2D> ().size = new Vector2 (Config.getMargemErro (), Config.getMargemErro ());
		InvokeRepeating ("gradualRotation", 0, 0.01f);
		InvokeRepeating ("atualizaSafe", 0, 0.1f);
	}
	// Update is called once per frame
	void Update(){
		if (Input.GetMouseButtonUp(0)){
			selected = false;
		}
	}
	private void atualizaSafe(){
		if (!bateu_barreira_) {
			last_safe_pos_ = transform.position;
			last_safe_rotation_ = transform.rotation;
		}
	}
	private void voltaPraSafe(){
		transform.position = last_safe_pos_;
		transform.rotation = last_safe_rotation_;
	}
	public void OnMouseOver(){
		if (Input.GetMouseButtonDown(0)){
			selected = true;
		}
	}

	public void BegingDrag(){
		bateu_barreira_ = false;
		if (!foi_dropado_certo_) {
			OffsetX = transform.position.x - Input.mousePosition.x;
			OffsetY = transform.position.y - Input.mousePosition.y;
			last_mouse_distant_pos = new Vector3 (OffsetX + Input.mousePosition.x, OffsetY + Input.mousePosition.y, 0);
		}
	}

	public void OnDrag(){
		if (!foi_dropado_certo_ && !bateu_barreira_) {
			atualizaRot ();
			atualizaPos ();
		}
	}
	private void gradualRotation(){
		if (lerp_rotation < 1) {
			lerp_rotation += 0.1f;
		}
		Vector3 my_rot = transform.rotation.eulerAngles;

		transform.rotation = Quaternion.Euler (new Vector3
			(0f,0f,Mathf.LerpAngle(my_rot.z,target_angle,lerp_rotation))
		);
	}
	private void atualizaPos(){
		transform.position = new Vector2 (OffsetX + Input.mousePosition.x, OffsetY + Input.mousePosition.y);
	}
	private void atualizaRot(){
		float angle = AngleBetweenTwoPoints(transform.position, new Vector3 (OffsetX + Input.mousePosition.x, OffsetY + Input.mousePosition.y, 0));
		if (Vector3.Distance (transform.position, last_mouse_distant_pos) > 20) {
			//transform.rotation = Quaternion.Euler (new Vector3(0f,0f,180+angle));
			target_angle = 180+angle;
			lerp_rotation = 0;
			last_mouse_distant_pos = new Vector3 (OffsetX + Input.mousePosition.x, OffsetY + Input.mousePosition.y, 0);
		}
	}
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
	public void OnEndDrag(){
		Debug.Log ("end"+Time.time);
		if (!foi_dropado_certo_) {
			if (estado_drop == DropState.CERTO) {
				transform.position = drop_pos_;
				foi_dropado_certo_ = true;
			} else {
				//transform.position = initial_pos_;	
			}
		}
	}
	public void barreira(){
		bateu_barreira_ = true;
		voltaPraSafe ();
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