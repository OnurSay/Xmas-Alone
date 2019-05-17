using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSound : MonoBehaviour {
    public GameObject portal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<AudioSource>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponent<AudioSource>().enabled = true;
        }
        
    }
}
