using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {
	public float speed = 0.0f;
	public float arrive_recognize = 0.1f;
	private bool flip_left = true;
	public Vector3 destination = Vector3.zero;
	private bool isArrive {
        get {
            return _isArrive;
        }
    }
	public bool _isArrive = true;
    
	private Rigidbody2D _rigidbody2d = null;
	private bool _flipleft = true;

	// Use this for initialization
	void Start () {
        
		_rigidbody2d = GetComponent<Rigidbody2D> ();
		Debug.Assert (null != _rigidbody2d);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}
    public bool isInGame {
        get {
            return _isInGame;
        } set {
            if (value) {
                StartCoroutine(example());
            }
            _isInGame = value;
        }
    }
    private bool _isInGame = false;
    IEnumerator example() {
        while (isInGame) {
            yield return null;
            Move();
        }
    }
	private void Move() {
		if (isArrive)
			return;
		Vector3 delta = destination - transform.position;
		//Debug.Log (delta.magnitude.ToString ());
		if (arrive_recognize >= delta.sqrMagnitude) {
			Stop ();
			if (gameObject.tag != "Player")
			    gameObject.SendMessage ("Arrive");
		} else {
			delta.Normalize ();
			_rigidbody2d.velocity = (Vector2)delta * speed;
		}
		//---- object flip
		Debug.Log(gameObject.tag + " "+delta.x);

		if (delta.x < 0) {
			gameObject.SendMessage ("Fliped", false);
		}
		if (delta.x > 0) {
			gameObject.SendMessage ("Fliped", true);
		}
	}
		//Debug.Log (destination.x - transform.position.x);
		

	public void SetDestination(Vector3 new_destination) {
		destination = new_destination;
		_isArrive = false;
	}

	public void Stop() {
		destination = Vector3.zero;
		_isArrive = true;
		_rigidbody2d.velocity = Vector2.zero;
	}
}
