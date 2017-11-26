using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_scroll : MonoBehaviour {
	public int scroll_length = 0;
	public float scroll_speed = 3f;

	[Header("Tagert paca")]
	public GameObject playerPaca;
	public GameObject LoadPaca;

    public RectTransform rectTransform;
    //private gameObject scroll_text;

    void Start () {
        //scroll_text = gameObject.GetComponent;
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine("Scroll_Up");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator Scroll_Up(){
	
		while (true) {
            rectTransform.anchoredPosition += new Vector2 (0, scroll_speed * Time.deltaTime);
            //yield return new WaitForFixedUpdate ();
            yield return null;
		}
	}
	void CallNextCutScene(){
		playerPaca.GetComponent<Opening_paca> ().coming ();

	}
}
