using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCapa : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		GameController.instance.gameStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		GameObject otherObj = other.gameObject;
		if(otherObj.CompareTag("Player")) {
			WearingPaca playerWearingPaca = otherObj.GetComponent<WearingPaca> ();
            playerWearingPaca.DumpAll();
		}
	}
}
