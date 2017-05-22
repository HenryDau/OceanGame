using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFloatDraggable : MonoBehaviour {

	public int X_BOUND = 150;
	public int Y_BOUND = 75;
	public float MAX_SPEED = 1.5f;

	private Rigidbody rb;
	private bool pressed = false;
	private bool released = false;
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 oldPosition;


	// Use this for initialization
	void Start () {
		int speed = Random.Range (5, 10);
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 ((float)speed / 10, 0, 0);
		//rb.velocity = new Vector3 (15 / 10, 0, 0);
	}

	void OnMouseDown(){

		pressed = true;

		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){

		oldPosition = transform.position;

		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint); //&#43; offset;

		transform.position = curPosition + offset;

	}

	void OnMouseUp(){
		pressed = false;
		released = true;

		rb.velocity = (transform.position - oldPosition) * Time.deltaTime * 5;
	}
	
	// Update is called once per frame
	void Update () {

		limitSpeed ();

		if (!pressed && !released) {

			// Rotate the trash
			transform.Rotate (Vector3.up * Time.deltaTime * 5);

			stayInBounds ();

			// Move the object
			transform.position = transform.position + rb.velocity;
		}

		if (released) {

			stayInBounds ();
			
			transform.position = transform.position + rb.velocity;
			
		}
	}

	void stayInBounds(){
		
		// Turn around if at the end of the map
		if ((rb.velocity.x > 0 && transform.position.x > X_BOUND) || (rb.velocity.x < 0 && transform.position.x < -X_BOUND))
			rb.velocity = new Vector3 (rb.velocity.x * -1, rb.velocity.y, 0);

		// Keep in the y bounds
		if ((transform.position.y > Y_BOUND && rb.velocity.y > 0) || (transform.position.y < -Y_BOUND && rb.velocity.y < 0))
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y * -1, 0);

		// Make sure it stays in the same plane
		if (rb.velocity.z != 0 || transform.position.z != 0) {
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, 0);
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		}
	}

	void limitSpeed(){
		if (rb.velocity.magnitude > MAX_SPEED) {
			rb.velocity = rb.velocity.normalized * MAX_SPEED;
		}
	}
}
