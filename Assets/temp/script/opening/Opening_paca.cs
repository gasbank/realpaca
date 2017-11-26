using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_paca : MonoBehaviour {
	public int ShakeTimeInput = 100;

	private int ShakeTime = 120;
	private int ticker = 40;	//까딱거리는 회수: shaketime/ticker
	private int count = 0 ;
	private int tick = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x"))
			StartCoroutine ("Shake");
	}
	public void coming(){
		transform.position = new Vector2(transform.position.x,transform.position.y+500f); 
	}
	public void ShakeHead(){
	}
	IEnumerator Shake(){
		while (true) {



			if(tick==1)transform.eulerAngles = new Vector3(0f, 0f, 3f);
			if(tick==0)transform.eulerAngles = new Vector3(0f, 0f, -3f);

			if (count++ > ticker) {
				tick ^= 1;
				count = 0;
			}
			if (ShakeTime-- < 0) {
				ShakeTime = ShakeTimeInput;
				yield break;
			}
			yield return new WaitForFixedUpdate();


		}

	}
}
