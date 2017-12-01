using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSetter : MonoBehaviour {
    private SpriteRenderer renderer = null;
    public int isflip = 0;

    [Header("Changed paca")]
    public Sprite hitted;
    private bool hasPaca = true;        // 양민 알파카들용 변수.
    public Sprite[] stackedPaca;
    public int maxpPacaLevel = 3;

    // Use this for initialization
    void Start() {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Flip();
    }
    void Flip() {
        if (isflip == 1) {
            renderer.flipX = true; // left
        } else if (isflip == 0) {
            renderer.flipX = false; // right
        }
    }
    public void Fliped() {
        isflip ^= 1;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (gameObject.tag == "Paca")
            if (other.gameObject.tag == "Player") {
                if (hasPaca) {
                    renderer.sprite = hitted;
                    other.gameObject.GetComponent<playerCount>().addPoint();
                    hasPaca = false;
                }
            }

    }
    //-- 파카 디자인 변경
    void upgradePaca() {
        int stacked = gameObject.GetComponent<playerCount>().getTempPoint();
        Debug.Log(stacked);
        if (stackedPaca.Length != 0 && stacked <= maxpPacaLevel) {
            try { renderer.sprite = stackedPaca[stacked]; } catch (System.Exception e) {; }
        }
    }
}
