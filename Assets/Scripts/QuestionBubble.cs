using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBubble : MonoBehaviour {

	private float speed;
	Vector3 position;
	float initialY;
	float amplitude = 20.0f;
	float phase_angle;

	// Use this for initialization
	void Start () {
		speed = Random.Range (-0.5f, -1.0f);
		initialY = transform.localPosition.y;
		phase_angle = Random.Range (0.0f, 360.0f);
	}

	// Update is called once per frame
	void Update () {
		position = transform.localPosition;
		if (position.x < -200) {
			Destroy (gameObject);
		}

		transform.localPosition = new Vector3 (
			position.x + speed,
			initialY + amplitude*Mathf.Sin(Time.fixedTime + phase_angle),
			position.z);
	}
}
