using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour {

	public void GameOver() {
		StartCoroutine (GameOverDelay ());
	}

	private IEnumerator GameOverDelay() {
		Player.instance.dead = true;
		yield return new WaitForSeconds(0.7f);

		Highscore.AddNewHighscore(GetComponent<WearingPaca>().totalScore);
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
	}
}
