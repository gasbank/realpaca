using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    // 파카 뺏을 때
    public AudioClip stealPakaClip;
    // 경찰에게 붙잡힐 때
    public AudioClip caughtClip;
    // 파카 아지트에 보관할 때
    public AudioClip dumpClip;
    // 경찰이 적극적으로 따라 붙을 때
    public AudioClip sirenClip;
    // 게임 오-버-
    public AudioClip gameOverClip;

    // Audio source
    public AudioSource sfxSource;
    internal float lastDamaged;
    internal bool dead;

    public NewPacaSprite newPacaSprite;
    public Canvas canvas;
    public float targetOrthographicSize;
    public float initialOrthographicSize;
    public float zoomInSpeed = 0.8f;
    public float zoomInOrthographicSize = 9;
    void Awake()
    {
        Application.targetFrameRate = 60;

        instance = this;
        targetOrthographicSize = Camera.main.orthographicSize;
        initialOrthographicSize = Camera.main.orthographicSize;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartNewPacaZoomIn();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ZoomOut();
        }

        float orthographicSizeDiff = targetOrthographicSize - Camera.main.orthographicSize;
        float orthographicSizeDiffK = zoomInSpeed * orthographicSizeDiff;
        Camera.main.orthographicSize += orthographicSizeDiffK;
    }

    public void ZoomOut()
    {
        //Camera.main.orthographicSize = 25;
        targetOrthographicSize = initialOrthographicSize;
        foreach (var sr in newPacaSprite.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.enabled = false;
        }
        canvas.enabled = true;
        Debug.Log("ZoomOut");
        //		GetComponent<DamageEffect> ().Pause = false;
        //		GameController.instance.gameStart ();
        Time.timeScale = 1;
    }

    public void StartNewPacaZoomIn()
    {
        //Camera.main.orthographicSize = 9;
        newPacaSprite.pacaNameSpriteRenderer.sprite = GetComponent<WearingPaca>().wear.pacaNameSprite;
        targetOrthographicSize = zoomInOrthographicSize;
        foreach (var sr in newPacaSprite.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.enabled = true;
        }
        canvas.enabled = false;
        Time.timeScale = 0;
        //		GameController.instance.gameStop ();
        GetComponent<DamageEffect>().Stop();
        StartCoroutine(ZoomOutDelayed());
    }

    IEnumerator ZoomOutDelayed()
    {
        PlayDumpClip();
        yield return new WaitForSecondsRealtime(2.0f);
        ZoomOut();
    }

    public void PlayStealPacaClip()
    {
        sfxSource.PlayOneShot(stealPakaClip);
    }

    public void PlayCaughtClip()
    {
        sfxSource.PlayOneShot(caughtClip);
    }

    public void PlayDumpClip()
    {
        sfxSource.PlayOneShot(dumpClip);
    }

    public void PlaySirenClip()
    {
        sfxSource.PlayOneShot(sirenClip);
    }

    public void PlayGameOverClip()
    {
        sfxSource.PlayOneShot(gameOverClip);
    }
}
