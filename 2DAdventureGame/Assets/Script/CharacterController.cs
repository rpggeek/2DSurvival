using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	//****************************************************************************
	private GameObject Clouds;
	private GameObject SubClouds;
	private GameObject MainCamera;
	private GameObject OksygenParticleSystem;
	private GameObject OksygenTank;
	//****************************************************************************
	public Rigidbody2D cameraRigidBody;
	public Rigidbody2D rigidd;
	//****************************************************************************
	public bool isWalking = false;
	public bool isTurnRight = true;
	//****************************************************************************
	private int heartCounter = 2;
	//****************************************************************************
	public List<GameObject> Hearth = new List<GameObject> ();
	//****************************************************************************

	void Start () {
		MainCamera = GameObject.Find("Main Camera");
		cameraRigidBody = MainCamera.GetComponent<Rigidbody2D> ();
		cameraRigidBody = GetComponent<Rigidbody2D> ();
		Hearth.Add(GameObject.Find("Hearth1"));
		Hearth.Add(GameObject.Find("Hearth2"));
		Hearth.Add(GameObject.Find("Hearth3"));
		Clouds = GameObject.Find ("Clouds");
		SubClouds = GameObject.Find ("SubClouds");
		OksygenParticleSystem = GameObject.Find ("OksygenSystem");
		OksygenTank = GameObject.Find ("Oksygen");
	}
	// Update is called once per frame
	void Update () {

		MovementSystem();
		OksygenSystem ();
		CameraSystem_that_FollowPlayer ();
	}

	//------------------------------------------------------------------------------------------------------
	void MovementSystem(){
		if (Input.GetKey (KeyCode.D)) {
			if (isTurnRight == false) {
				transform.Rotate (0, 180, 0);
				isTurnRight = true;
			}
			isWalking = true;
			cameraRigidBody.transform.Translate (Vector2.right * Time.deltaTime*6);
		}else {
			isWalking = false;
		}


		if (Input.GetKey (KeyCode.A)){
			if (isTurnRight) {
				transform.Rotate (0, 180, 0);
				isTurnRight = false;
			}
			isWalking = true;
			cameraRigidBody.transform.Translate (-Vector2.left * Time.deltaTime*6);
		} else {
			isWalking = false;
		}
	}
	//------------------------------------------------------------------------------------------------------
	void OksygenSystem (){
		if(OksygenParticleSystem.GetComponent<ParticleSystem>().time%10 < 0.1F){
			OksygenParticleSystem.transform.position = OksygenTank.transform.position;
		}
	}

	//------------------------------------------------------------------------------------------------------

	void CameraSystem_that_FollowPlayer(){
		float distance = Vector2.Distance (MainCamera.transform.position, transform.position);
		Vector2 direction = transform.position - MainCamera.transform.position;

		if (distance > 6 && direction.x > 0) {
			MainCamera.transform.Translate (Vector2.right*Time.deltaTime*3.5F);
			Clouds.transform.Translate (Vector2.right * Time.deltaTime*2);
			SubClouds.transform.Translate (Vector2.right * Time.deltaTime*1.8F);
		}
		if (distance > 6 && direction.x < 0) {
			MainCamera.transform.Translate (Vector2.left*Time.deltaTime*3.5F);
			Clouds.transform.Translate (Vector2.left * Time.deltaTime*2);
			SubClouds.transform.Translate (Vector2.left * Time.deltaTime*1.8F);
		}
	}
	//------------------------------------------------------------------------------------------------------
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.name == "blade" || collision.gameObject.name == "blade_2") {
			Destroy (Hearth[heartCounter]);
			heartCounter--;
		}
	}
	//------------------------------------------------------------------------------------------------------
	}

