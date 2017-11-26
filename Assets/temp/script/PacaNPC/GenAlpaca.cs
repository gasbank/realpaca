using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenAlpaca : MonoBehaviour {
	public GameObject capObj;
	public int needToExist;
	public float checkInterval;
	public float safetyZoneRadius = 12.0f;
	public float pacaAlpacaSpawnRadius = 50.0f;
	public GameObject alpacaPrefab;
	public Paca[] pacaList;

	private System.Random rnd = new System.Random((int)System.DateTime.Now.Ticks);

	// Use this for initialization
	private void Awake () {
		IEnumerator genCo = GenerateCo ();
		GameController.instance.onGameStart += () => {
			StartCoroutine (genCo);
		};
		GameController.instance.onGameStop += () => {
			StopCoroutine(genCo);
		};
	}

	int UpCeil(int n) {
		if (0 == n % 10)
			return n / 10;
		else 
			return ((n / 10) * 10)+1;
	}

	private IEnumerator GenerateCo() {
		while (true) {
			needToExist = (int)(UpCeil (capObj.transform.childCount) * 2.5f);
			needToExist = needToExist == 0 ? 10 : needToExist;

			for (int i = 0; i < needToExist - transform.childCount; ++i) {
				var go = Instantiate(alpacaPrefab);
				go.GetComponent<SettingPaca>().SetData(pacaList[rnd.Next(0, pacaList.Length)]);
				go.GetComponent<PacaMove> ().StartMove ();
				var spawnPoint = UnityEngine.Random.insideUnitCircle * pacaAlpacaSpawnRadius;
				go.transform.position = spawnPoint;
				go.transform.parent = transform;
			}

			yield return new WaitForSeconds (checkInterval);
		}
	}
}
