using System.Collections;
using UnityEngine;

public class CopCollide : MonoBehaviour {
	public Dialog dialog;
	private int i = 20;
	void OnTriggerEnter2D(Collider2D other) {
		GameObject otherObj = other.gameObject;
		if (otherObj.CompareTag ("Player")) {
            // 데미지 입었을 때 그 다음 데미지까지 1초 쿨타임
            if (Time.time - Player.instance.lastDamaged > 1.0f)
            {
                Player.instance.lastDamaged = Time.time;

                dialog.selectDialogEvent();

                WearingPaca playerWearingPaca = otherObj.GetComponent<WearingPaca>();
                Player.instance.PlayCaughtClip();
                Player.instance.GetComponent<DamageEffect>().SetToRed();
                if (playerWearingPaca.Score == 0)
                {
                    Highscore.AddNewHighscore(Player.instance.GetComponent<WearingPaca>().totalScore);
                    Player.instance.dead = true;
                    // 너무 바로 Game over 신으로 가지 않도록 한다....
                    StartCoroutine(LoadGameOverDelayed());
                    // gameover
                }
                else
                {
                    playerWearingPaca.RemoveAllPaca();
                }
            }
		}
	}
	public void DestroyDeleyed(){
		StartCoroutine ("Delayed");
	}

    IEnumerator LoadGameOverDelayed()
    {
        yield return new WaitForSeconds(0.7f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
	IEnumerator Delayed(){

		SpriteRenderer randerer = gameObject.GetComponent<SpriteRenderer> ();
		while (true) {
			if (i % 2 == 0) {
				randerer.color = new Color32 (255, 255, 255, 250);
			} else
				randerer.color = new Color32 (255, 255, 255, 90);
			if (i-- < 0) {
				yield break;
			}
			yield return new WaitForSeconds (0.1f);
		}
	}

}
