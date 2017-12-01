using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacasprite : MonoBehaviour {
	private SpriteRenderer renderer = null;

	[Header("Changed paca")]
	public Sprite hitted;
	private bool hasPaca = true;		// 양민 알파카들용 변수.
	public Sprite[] stackedPaca;
	public int maxpPacaLevel = 3;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer> ();
	}

	public void Fliped(bool value){
		renderer.flipX = value;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (gameObject.tag == "Paca")
		if (other.gameObject.tag == "Player") {
			if (hasPaca) {
				renderer.sprite = hitted;
				other.gameObject.GetComponent<playerCount> ().addPoint ();
				hasPaca=false;
			}
		}

	}
	//-- 파카 디자인 변경
	void upgradePaca(){
		int stacked = gameObject.GetComponent<playerCount>().getTempPoint();
		//Debug.Log (stacked);
		if (stackedPaca.Length != 0 && stacked <= maxpPacaLevel) {
			try{renderer.sprite = stackedPaca [stacked];}
			catch(System.Exception e){;}
		}
	}


}
