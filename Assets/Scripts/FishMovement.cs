using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Hi boys, just a harmless comment swimming thru a seamless 
//git commit, hopefully :)
public class FishMovement : MonoBehaviour {
	public int MIN_X = -20;
	public int MIN_Y = -20;
	public int MAX_X = 20;
	public int MAX_Y = 20;
	public int MIN_SPEED = 1;
	public int MAX_SPEED = 2;
	private Rigidbody2D rb2d;
	private Vector2 goalPoint;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		selectNewPoint();

	}
	
	// Update is called once per frame
	void Update () {
		if (pointReached()) {
			selectNewPoint ();
		}
	}

	private void selectNewPoint()
	{
		goalPoint.x = Random.Range ((float)MIN_X, (float)MAX_X);
		goalPoint.y = Random.Range ((float)MIN_Y, (float)MAX_Y);
		rb2d.velocity = (goalPoint - rb2d.position).normalized * Random.Range (MIN_SPEED, MAX_SPEED);
		Vector2 dir = rb2d.velocity;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		if (angle > 90 && angle < 270) {
			transform.localScale = new Vector3 (1, -1, 1);
		}


	}
	private bool pointReached(){
		return (goalPoint - rb2d.position).magnitude < 1;
	}

}
