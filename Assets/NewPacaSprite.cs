using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPacaSprite : MonoBehaviour
{
    public SpriteRenderer pacaNameSpriteRenderer;

    private void Awake()
    {
        
    }

    void ResizeSpriteToScreen()
    {
        //if (transform.childCount > 0)
        //{
        //    var newPacaNameObject = transform.GetChild(0);
        //    if (newPacaNameObject)
        //    {
        //        pacaNameSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        //    }
        //}

        var sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;

        var worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        
        transform.localScale = new Vector3(Player.instance.transform.localScale.x * worldScreenWidth / width * 1.01f, worldScreenHeight / height * 1.01f, 1);


    }

    private void Update()
    {
        if (pacaNameSpriteRenderer)
        {
            pacaNameSpriteRenderer.transform.localScale = new Vector3(2, 2, 1);
        }
    }

    private void LateUpdate()
    {
        ResizeSpriteToScreen();
    }
}
