using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealPaca : MonoBehaviour
{
	public bool NPZ = true;	//NewPacaZoomin
	private WearingPaca wearingPaca;
    public Dictionary<Paca, int> stealStat = new Dictionary<Paca, int>();

    private void Awake() {
		wearingPaca = gameObject.GetComponent<WearingPaca> ();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.Space))
		//	wearingPaca.RemoveAllPaca ();
	}

	void OnTriggerEnter2D(Collider2D other) {
//		Debug.Log ("collide");
		GameObject otherObj = other.gameObject;
		if (otherObj.CompareTag ("PacaNPC")) {
//			Debug.Log ("other is paca npc");
			WearingPaca otherWearingPaca = otherObj.GetComponent<WearingPaca> ();
			Paca otherPaca = otherWearingPaca.LostWearPaca ();
            
            Player.instance.PlayStealPacaClip();
		    if (null != otherPaca)
		    {
		        wearingPaca.WearNewPaca(otherPaca);
		        var otherPacaMove = otherObj.GetComponent<PacaMove>();
		        if (null != otherPacaMove)
		        {
		            otherPacaMove.StartFlee();
		        }
		    }

			try{
				if (NPZ&&(false == stealStat.ContainsKey(otherPaca)))
	            {
	                Player.instance.StartNewPacaZoomIn();
	                stealStat[otherPaca] = 1;
	            }
	            else
	            {
	                stealStat[otherPaca]++;
				}
			}
			catch(System.Exception e){
				;
			}
			/*

			*/
        }
    }
	public void offNPZ(){
		NPZ = false;
	}
	public void onNPZ(){
		NPZ = true;
	}
}
