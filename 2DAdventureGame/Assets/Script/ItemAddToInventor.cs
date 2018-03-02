using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAddToInventor : MonoBehaviour {
	// Use this for initialization
	private GameObject inventory;
	Sprite Knife;
	void Start () {
		inventory = GameObject.Find ("Slot1");
		Knife = Resources.Load<Sprite> ("Knife");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		inventory.GetComponent<Image> ().sprite = Knife;
	}
}
