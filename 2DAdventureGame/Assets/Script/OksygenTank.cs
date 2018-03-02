using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OksygenTank : MonoBehaviour {
	int timer = 0;
	// Use this for initialization
	private GameObject OksygenSystem;
	void Start () {
		OksygenSystem = GameObject.Find ("OksygenSystem");
	}
	
	// Update is called once per frame
	void Update () {
		if(OksygenSystem.GetComponent<ParticleSystem>().time%10 < 0.1F){
			GetComponent<RectTransform> ().sizeDelta = new Vector2 (133.8F-timer, 16.2F);
			timer += 1;
		}
	}
}
