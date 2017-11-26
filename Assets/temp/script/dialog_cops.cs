using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog_cops : MonoBehaviour {
	public Dialog dialog;
	void OnTriggerEnter2D(Collider2D other){
//		Debug.Log (other.ToString ());
		if (other.gameObject.tag=="Player"){
//			Debug.Log ("mbox collide");
			dialog.selectDialog();
		}
	}
}
