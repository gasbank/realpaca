using System.Collections;
using UnityEngine;

public class Opening : MonoBehaviour {
    public UnityEngine.UI.Image image;
    public Opening_scroll openingScroll;
    public RectTransform logBox;

    private void Awake()
    {
        image.color = Color.black;
    }
    
	// Use this for initialization
	IEnumerator Start () {
        openingScroll.enabled = true;

        float curtainAlpha = 1.0f;
        while (curtainAlpha > 0)
        {
            image.color = new Color(0, 0, 0, curtainAlpha);
            curtainAlpha -= Time.deltaTime * 0.2f;
            yield return null;
        }
        image.color = Color.clear;
        
        yield return new WaitUntil(() => logBox.anchoredPosition.y > 325.0f);
        while (curtainAlpha < 1.0f)
        {
            image.color = new Color(0, 0, 0, curtainAlpha);
            curtainAlpha += Time.deltaTime * 0.2f;
            yield return null;
        }
        image.color = Color.black;
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }
	
    public void SkipScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }
}
