using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryCheck : MonoBehaviour {
    public static bool Entry = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShakeEffect>().enabled = true;
        Entry = true;
    }
}
