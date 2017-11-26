using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {
	public Sprite [] list_dialog;			//0 = 기초 
	public Sprite [] list_dialog_event;
	public Transform[] dialogPositions;
	public float tellInterval = 4.0f;

	private Vector3 defaultScale;
	private GameObject teller;
	private SpriteRenderer textBubble;
	private float timer=0;
	private IEnumerator slowlyCo;

	// Use this for initialization
	private void Awake () {
		defaultScale = transform.localScale;
		timer = 0.0f;
		textBubble = gameObject.GetComponent<SpriteRenderer> ();

		// find teller
		Transform parent = transform;
		while (null != (parent = parent.parent)) {
			if (parent.CompareTag ("PacaNPC") ||
			   parent.CompareTag ("Enemy"))
				break;
		}
		if(null != parent)
			teller = parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		SetProperTransform ();
	}

	private void SetProperTransform() {
		if (null == teller)
			return;
		
		if (teller.transform.localScale.x < 0.0f) {
			transform.position = dialogPositions [1].position;
			transform.localScale = new Vector3 (-1.0f*defaultScale.x, defaultScale.y, defaultScale.z);
		} else if(teller.transform.localScale.y  > 0.0f) {
			transform.position = dialogPositions [0].position;
			transform.localScale = defaultScale;
		}
	}

	public void selectDialog(){
		if (timer > 0.0f) {
			return;
		}
		if(null != slowlyCo)
			StopCoroutine (slowlyCo);
		timer = tellInterval;
//		Debug.Log ("texted");
		textBubble.sprite = list_dialog[Random.Range (1, list_dialog.Length - 1)];
		slowlyCo = Slowly ();
		StartCoroutine (slowlyCo);
	}

	public void selectDialogEvent(){
		if (timer > 0.0f) {
			return;
		}
		if (null != slowlyCo)
			StopCoroutine (slowlyCo);
		timer = tellInterval;
		textBubble.sprite = list_dialog_event[Random.Range (1, list_dialog_event.Length - 1)];
		slowlyCo = Slowly ();
		StartCoroutine (slowlyCo);
	}

	void setDefault(){
		textBubble.sprite = list_dialog [0];
	}

	IEnumerator Slowly(){
		while (true) {
			yield return new WaitForFixedUpdate ();
			timer -= Time.deltaTime;
				if (timer < 0.0f) {
				setDefault ();
				yield break;
			}
		}
	}
}
