using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFloatPoof : MonoBehaviour {

	public int X_BOUND = 150;
	public int Y_BOUND = 75;
	public float MAX_SPEED = 1.5f;

	private Rigidbody rb;
 



    // Use this for initialization
    void Start () {
		int speed = UnityEngine.Random.Range (5, 13);
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 ((float)speed / 10, 0, 0);
    }

	void OnMouseDown(){
        GameObject Dropplay = GameObject.Find("Playdrop");//will need updated if proper sound controls are implemented
        Playdropscript drop = Dropplay.GetComponent<Playdropscript>();
        drop.play();

        Destroy(gameObject);

        //Finds Points and references public variable
        GameObject PointCounter = GameObject.Find("Points");
        PointCounter Points = PointCounter.GetComponent<PointCounter>();
        Points.point += 1;

       
       
	}

 
    // Update is called once per frame
    void Update () {
       
            // Rotate the trash
            transform.Rotate (Vector3.up * Time.deltaTime * 5);

		// Get the position
		Vector3 pos = transform.position;

		// Turn around if at the end of the map
		if ((rb.velocity.x > 0 && pos.x > X_BOUND) || (rb.velocity.x < 0 && pos.x < -X_BOUND))
			rb.velocity = new Vector3( rb.velocity.x * -1, rb.velocity.y, rb.velocity.z);
		

		// Keep in the y bounds
		if (pos.y > Y_BOUND && rb.velocity.y > 0 || (pos.y < -Y_BOUND && rb.velocity.y < 0))
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y * -1, rb.velocity.z);
		

		// Make sure it stays in the same plane
		if (rb.velocity.z != 0 || pos.z != 0) {
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, 0);
			transform.position = new Vector3 (pos.x, pos.y, 0);
		}

		limitSpeed ();

		// Move the object
		transform.position = transform.position + rb.velocity;
	}

	void limitSpeed(){
		if (rb.velocity.magnitude > MAX_SPEED) {
			rb.velocity = rb.velocity.normalized * MAX_SPEED;
		}
	}
}
