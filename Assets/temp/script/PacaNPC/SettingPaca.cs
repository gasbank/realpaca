using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPaca : MonoBehaviour {
	public Paca paca;
	private WearingPaca wearingPaca;

	private void Awake()
	{
	    SetData(paca);
	}

    public void SetData(Paca newPaca)
    {
        paca = newPaca;
        wearingPaca = GetComponent<WearingPaca>();
        wearingPaca.WearNewPaca(paca);
        GetComponent<Animator>().runtimeAnimatorController = paca.alpacaAnimator;
    }
}
