using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopGenerator : MonoBehaviour {
	[Header("Gen Info")]
	public int initialCopCount = 10;
	public int maxCopCount = 12;
	public int difficultyInfluence = 5;
	public float countCheckInterval = 5.0f;
	public float minGenDistance = 60.0f;
	public float maxGenDistance = 120.0f;

	[Header("Difficulty")]
	public float difficultyUpRate = 10.0f;
	public int difficulty = 50;

	public GameObject mob_prefab = null;
	[Header("Target")]
	public GameObject target = null;


	// Use this for initialization
	private void Awake() {
		Debug.Assert (null != mob_prefab);
		Debug.Assert (null != target);

		IEnumerator genCo = GenerateCo ();
		IEnumerator difUpdateCo = DifficultyUpdate ();
		GameController.instance.onGameStart += () => {
			StartCoroutine (genCo);
			StartCoroutine (difUpdateCo);
		};
		GameController.instance.onGameStop += () => {
			StopCoroutine(genCo);
			StopCoroutine(difUpdateCo);
		};

		for (int i = 0; i < initialCopCount; ++i) {
			Vector3 pos = GenPos () + target.transform.position;
			GameObject new_mob = (GameObject)Instantiate (mob_prefab, pos, Quaternion.identity);
			new_mob.transform.parent = transform;
			new_mob.SendMessage("SetTarget", target);
		}
	}


	private float GetDifficultyUpInterval() {
		return Mathf.Sqrt (difficultyUpRate * difficulty);
	}

	private IEnumerator DifficultyUpdate() {
		while (true) {
			yield return new WaitForSeconds (GetDifficultyUpInterval ());
			maxCopCount += difficultyInfluence;
			++difficulty;
            Debug.Log(difficulty);
		}
	}

	private IEnumerator GenerateCo() {
		while (true) {
			for (int i = 0; i < maxCopCount - transform.childCount; ++i) {
				Vector3 pos = GenPos () + target.transform.position;
				GameObject new_mob = (GameObject)Instantiate (mob_prefab, pos, Quaternion.identity);
				new_mob.GetComponent<Trace> ().StartTrace ();
				new_mob.transform.parent = transform;
				new_mob.SendMessage("SetTarget", target);
			}
			yield return new WaitForSeconds (countCheckInterval);
		}
	}

	private Vector3 GenPos() {
		float angle = Random.Range (0.0f, 360.0f);
		Vector3 result = Quaternion.Euler (0.0f, 0.0f, angle) * Vector3.right * Random.Range(minGenDistance, maxGenDistance);

		result.z = -1.0f;

		return result;
	}
}
