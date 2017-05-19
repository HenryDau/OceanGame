using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFloat : MonoBehaviour {

	public int speed = 0;
	public int smoothness = 5;

	private int counter = 0;
	private bool pressed = false;
	private Vector3 screenPoint;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDown(){

		pressed = true;
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){

		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint); //&#43; offset;
		transform.position = curPosition + offset;

		/*pressed = true;
		Debug.Log ("Pressed left click.");

		transform.localPosition = new Vector3 (
			transform.localPosition.x,
			(float)(.5 - Random.value) * 150,
			transform.localPosition.z
		);

		offset = scanPos - Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));


		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;*/
	}

	void OnMouseUp(){
		pressed = false;
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");

			transform.localPosition = new Vector3 (
				transform.localPosition.x,
				(float)(.5 - Random.value) * 150,
				transform.localPosition.z
			);
		}*/
		
		transform.Rotate(Vector3.up * Time.deltaTime * 5);
		counter++;

		if (counter % smoothness == 0 && !pressed){

			// Get the position
			Vector3 pos = transform.localPosition;

			// Turn around if at the end of the map
			if (speed > 0 && pos.x > 175) {
				speed *= -1;
			} else if (speed < 0 && pos.x < -175) {
				speed *= -1;
			}

			// Move the object
			transform.localPosition = new Vector3 (
				pos.x + speed,
				pos.y,
				pos.z
			);
		}
	}
}
