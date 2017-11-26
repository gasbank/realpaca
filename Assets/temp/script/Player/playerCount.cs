using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCount : MonoBehaviour {
	//--점수채점용.

	public int totalPoint = 0;
	public int tempPoint = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Safe") {
			totalPoint += tempPoint;
			tempPoint = 0;
//			gameObject.SendMessage ("upgradePaca");
		}
		if (other.gameObject.tag == "Enemy") {
			tempPoint = 0;
//			gameObject.SendMessage ("upgradePaca");
		}
	}
	public void addPoint(){
		tempPoint++;
//		gameObject.SendMessage ("upgradePaca");
	}
	public int getTempPoint(){
		return tempPoint;
	}
}
