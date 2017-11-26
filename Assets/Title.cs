using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public UnityEngine.UI.Image image;

	private int toggle = 0;

    private void Awake()
    {
        image.color = Color.black;
    }

    IEnumerator Start()
    {
        //yield return new WaitForSeconds(2.0f);
        float curtainAlpha = 1.0f;
        while (curtainAlpha > 0)
        {
            image.color = new Color(0, 0, 0, curtainAlpha);
            curtainAlpha -= Time.deltaTime * 0.3f;
            yield return null;
        }
        image.color = Color.clear;
        image.gameObject.SetActive(false);
    }

    public void LoadTest()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("test");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

	public void setNPZ(){
		//stealpaca의 offNPZ / onNPZ 호출, 토글식
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (toggle == 1) {player.GetComponent<StealPaca> ().onNPZ ();}
		if (toggle == 0) {player.GetComponent<StealPaca> ().offNPZ ();}
		toggle ^= 1;
	}


}
