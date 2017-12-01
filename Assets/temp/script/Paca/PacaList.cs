using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacaList : MonoBehaviour {
    public List<Paca> list = new List<Paca>();

    public void AddPaca(Paca paca) {
        list.Add(paca);
    }

    public Paca FindPaca(string name) {
        for (int i = 0; i < list.Count; ++i) {
            if (list[i].name == name)
                return list[i];
        }
        return null;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
