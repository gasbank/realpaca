using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfence : MonoBehaviour {
	//public bool inSafe = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
//		Debug.Log ("area in : " + other.tag);
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<CopCollide> ().DestroyDeleyed();
			Destroy (other.gameObject,3f);
		}
	}


}
