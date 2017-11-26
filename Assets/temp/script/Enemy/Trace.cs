using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour {
	public GameObject target;
	public float speed;
	public float destroyDistance;

	[Header("Time")]
	public float min_traceTime;
	public float max_traceTime;
	public float min_waitTime;
	public float max_waitTime;

	private IEnumerator move;
	private IEnumerator timeCheck;
	private bool nowTracing = true;

	private SpriteRenderer renderer2d;

	private void Awake() {
		renderer2d = GetComponent<SpriteRenderer> ();

		move = Move ();
		timeCheck = TraceTimeCheck ();

		GameController.instance.onGameStart += () => {
			StartCoroutine (move);
			StartCoroutine (timeCheck);
		};
		GameController.instance.onGameStop += () => {
			StopCoroutine (move);
			StopCoroutine (timeCheck);
		};
	}

	public void StartTrace() {
		if (null == move)
			move = Move ();
		if (null == timeCheck)
			timeCheck = TraceTimeCheck ();
		StartCoroutine (move);
		StartCoroutine (timeCheck);
	}

	private IEnumerator Move() {
		while (true) {
			if (null == target || false == nowTracing)
				yield return null;

			Vector3 target_pos = target.transform.position;
			Vector3 delta = target_pos - transform.position;

			delta.Normalize ();

			transform.Translate ((delta * speed * (1+transform.parent.GetComponent<CopGenerator>().difficulty * 0.1f)) * Time.deltaTime);

			if (delta.x > 0.0f) {
				renderer2d.flipX = true;
			} else if (delta.x < 0.0f) {
				renderer2d.flipX = false;
			}
			yield return null;
		}
	}

	private IEnumerator TraceTimeCheck() {
		yield return new WaitForSeconds (Random.Range(min_traceTime, max_traceTime));
		nowTracing = false;
		yield return new WaitForSeconds (Random.Range(min_waitTime, max_waitTime));
		nowTracing = true;
		yield return new WaitForSeconds (Random.Range(min_traceTime, max_traceTime));
		Destroy (gameObject,3f);
		gameObject.SendMessage ("DestroyDeleyed");
	}

	public void SetTarget(GameObject newtarget) {
		target = newtarget;
	}
	public void traced_off(){
		nowTracing = false;
	}
	public void traced_on(){
		nowTracing = true;
	}


}
