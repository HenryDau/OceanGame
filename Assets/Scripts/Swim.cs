using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour {

	public int speed = 0;
	public int smoothness = 10;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		counter++;
		if (counter % smoothness == 0){
			Vector3 pos = transform.localPosition;
			if (speed > 0 && pos.x > 175) {
				speed *= -1;
				transform.Rotate (Vector3.up, 180);
				pos.y = (float)(.5 - Random.value) * 150;
			} else if (speed < 0 && pos.x < -175) {
				speed *= -1;
				transform.Rotate (Vector3.up, 180);
				pos.y = (float)(.5 - Random.value) * 150;
			}
			transform.localPosition = new Vector3 (
				pos.x + speed,
				pos.y,
				pos.z
			);
		}
	}

	/*void OnMouseDown(){
		Debug.Log ("Pressed left click.");

		transform.localPosition = new Vector3 (
			transform.localPosition.x,
			(float)(.5 - Random.value) * 150,
			transform.localPosition.z
		);
	}*/

}
