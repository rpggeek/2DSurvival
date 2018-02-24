using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D rigid;
	public Rigidbody2D rigidd;
	public bool yürüdü = false;
	public bool sag_dondu = true;
	private int objecttimer = 2;
	public List<GameObject> hearth = new List<GameObject> ();

	public GameObject Cam;
	void Start () {
		Cam = GameObject.Find("Main Camera");
		rigidd = Cam.GetComponent<Rigidbody2D> ();
		rigid = GetComponent<Rigidbody2D> ();
		hearth.Add(GameObject.Find("Hearth1"));
		hearth.Add(GameObject.Find("Hearth2"));
		hearth.Add(GameObject.Find("Hearth3"));

	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.D)) {
			if (sag_dondu == false) {
				transform.Rotate (0, 180, 0);
				sag_dondu = true;
			}
			yürüdü = true;
			rigid.velocity = new Vector3 (5, 0, 0);
		}else {
			yürüdü = false;
		}
		if (Input.GetKeyDown (KeyCode.A)){
			if (sag_dondu) {
				transform.Rotate (0, 180, 0);
				sag_dondu = false;
			}
			yürüdü = true;
			rigid.velocity = new Vector3 (-5, 0, 0);
		} else {
			yürüdü = false;
		}
		float distance = Vector2.Distance (Cam.transform.position, transform.position);
		Vector2 direction = transform.position - Cam.transform.position;
	
		if (distance > 10 && direction.x > 0) {
			Cam.transform.Translate (Vector2.right*Time.deltaTime*3.5F);
			//Cam.transform.position += (transform.position - Cam.transform.position).normalized * Time.deltaTime * 3;
		}
		if (distance > 10 && direction.x < 0) {
			Cam.transform.Translate (Vector2.left*Time.deltaTime*3.5F);
			//Cam.transform.position += (transform.position - Cam.transform.position).normalized * Time.deltaTime * 3;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "blade" || coll.gameObject.name == "blade_2") {
			Destroy (hearth[objecttimer]);
			objecttimer--;
		}
	}

	}

