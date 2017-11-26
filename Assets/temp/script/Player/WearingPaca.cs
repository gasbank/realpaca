using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearingPaca : MonoBehaviour {
	public Transform pacaBag;
	public SpriteRenderer wearingPaca;    
    public List<Paca> bagedPacas;
	public Paca wear = null;
	public GameObject bagedPacaPrefab;
    public int _totalScore;
    public float stackHeight = 1.0f;

    public int totalScore
    {
        get { return _totalScore; }
        set
        {
            _totalScore = value;
            if (totalScoreText)
            {
                totalScoreText.text = string.Format("Score: {0}", _totalScore);
            }
        }
    }
    public UnityEngine.UI.Text totalScoreText;
    
    public int Score { 
		get {
			if (null == wear)
				return 0;
			else
				return (bagedPacas.Count + 1);
		}
	}

	private void Awake()
	{
	    totalScore = 0;
	}

	public void WearNewPaca(Paca paca) {
		if (null != wear && bagedPacaPrefab) {
			GameObject newStackedPaca = Instantiate (bagedPacaPrefab, pacaBag);
//			Debug.Log (newStackedPaca.name, newStackedPaca);
			newStackedPaca.GetComponent<SpriteRenderer> ().sprite = wear.bagSprite;
            newStackedPaca.transform.localPosition = Vector3.up * stackHeight * bagedPacas.Count;
			bagedPacas.Add (wear);
		}
//		Debug.Log (paca.ToString ());
		wear = paca;
	    if (wear)
	    {
            wearingPaca.sprite = wear.wearSprite;
	    }
    }

	public void RemoveAllPaca() {
		foreach (Transform child in pacaBag) {
			Destroy (child.gameObject);
		}
		bagedPacas.Clear ();
		LostWearPaca ();
	}

	public Paca LostWearPaca() {
		if (null == wear)
			return null;
		Paca result = wear;
		wear = null;
		wearingPaca.sprite = null;
		return result;
	}

    public void DumpAll()
    {
        if (Score > 0)
        {
            Player.instance.PlayDumpClip();
        }
        totalScore += Score;
        RemoveAllPaca();
    }
}
