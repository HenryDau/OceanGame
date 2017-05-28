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
		if (!GlobalVariables.isPaused) {
			position = transform.localPosition;
			if (position.x < -200) {
				Destroy (gameObject);
			}

			transform.localPosition = new Vector3 (
				position.x + speed,
				initialY + amplitude * Mathf.Sin (Time.fixedTime + phase_angle),
				position.z);
		}
	}

	public bool showQuestion = false;
	public bool doWindow0 = false;

	void DoWindow0(int windowID) {
		if (GUI.Button (new Rect (40, 100, 110, 40), "Answer 1")) {
			GlobalVariables.isPaused = false;
			showQuestion = false;
		}
		GUI.Button(new Rect(160, 100, 110, 40), "Answer 2");
		GUI.Button(new Rect(40, 150, 110, 40), "Answer 3");
		GUI.Button(new Rect(160, 150, 110, 40), "Answer 4");


	}

	void OnGUI() {
		if (showQuestion) {			
			GUI.Window (0, new Rect (450, 130, 300, 200), DoWindow0, "Basic Window");
		}
	}

	void OnMouseDown() {
		showQuestion = true;
		GlobalVariables.isPaused = true;
	}
}
