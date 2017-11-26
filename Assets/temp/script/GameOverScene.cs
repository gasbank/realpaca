using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour {
	public void ToScoreScene() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("highscore");
	}
}
