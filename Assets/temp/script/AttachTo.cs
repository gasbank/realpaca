using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTo : MonoBehaviour {
	public GameObject attachTo;
	public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
		transform.position = attachTo.transform.position + offset;
	}
}
