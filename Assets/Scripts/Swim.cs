using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour {

	public int speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
			pos.x + (float) speed / 10,
			pos.y,
			pos.z
		);
	}

}
