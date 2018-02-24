using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

	// Use this for initialization
	public GameObject Cam;
	public float distance = 0;
	void Start () {
		Cam = GameObject.Find("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector2.Distance (transform.position, Cam.transform.position);
		Vector2 direction = transform.position - Cam.transform.position;
		if (distance > 5 && direction.x > 0) {
			transform.Translate (Vector2.right*Time.deltaTime*3.5F);
		}
		if (distance > 5 && direction.x < 0) {
			transform.Translate (Vector2.left*Time.deltaTime*3.5F);
		}
	}
}
