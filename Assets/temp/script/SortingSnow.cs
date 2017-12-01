using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSnow : MonoBehaviour {
	public string layerName;

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystemRenderer> ().sortingLayerName = layerName;
		GetComponent<ParticleSystem> ().Simulate (100.0f);
		GetComponent<ParticleSystem> ().Play ();
	}
}
