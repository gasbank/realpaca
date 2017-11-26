using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour {


	private SpriteRenderer house;
	private Dialog dialog;

	// Use this for initialization
	void Start () {
		house = gameObject.GetComponent<SpriteRenderer> ();
		dialog = transform.GetChild (0).gameObject.GetComponent<Dialog> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
//		Debug.Log (other.ToString ());
		if (other.gameObject.tag == "Player") {
			StartCoroutine ("Open_Slowly");
			dialog.selectDialog ();
			//	house.sprite = house_open;
		} else if (other.gameObject.tag=="Enemy"||other.gameObject.tag=="PacaNPC") {
			Destroy (other.gameObject);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "PacaNPC") {
			Destroy (other.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			StartCoroutine ("Close_Slowly");
			dialog.selectDialogEvent ();
		//	house.sprite = house_close;
		} else if (other.gameObject.tag=="Enemy"||other.gameObject.tag=="PacaNPC"){
			Destroy (other.gameObject);
		}
	}
	IEnumerator Open_Slowly(){
		int timer = 10;
		while (true) {
			house.color = new Color32 (255, 255, 255,(byte) (25.6 * (10-timer)));

			yield return new WaitForFixedUpdate ();

			if (timer-- < 0)
				yield break;
			}
		}
	IEnumerator Close_Slowly(){
		int timer = 10;
		while (true) {
			house.color = new Color32 (255, 255, 255, (byte)(25.6 * (timer)));

			yield return new WaitForFixedUpdate ();

			if (timer-- < 0) {
				yield break;
			}
		}
	}
}
