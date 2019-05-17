using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenEnterToy : MonoBehaviour {
    public AudioSource Source;
    public AudioClip Ambient;
    bool isPlayed = false;
	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
		if(Inventory.goldenKey == 1 && isPlayed == false)
        {
            Source.PlayOneShot(Ambient);
            isPlayed = true;
        }
	}
}
