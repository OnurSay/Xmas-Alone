using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaJumpScare : MonoBehaviour {
    public AudioClip jumpscare2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(JumpScare.dayiGeldi == true)
        {
            GetComponent<AudioSource>().Play();
            
        }
	}
}
