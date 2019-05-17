using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourtNoteReleaser : MonoBehaviour {
    bool keystep2 = false;
    public GameObject FourthNote;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(MeshAgentCollider.keyStep1 == true && keystep2 == true)
        {
            FourthNote.SetActive(true);
            GameObject.FindGameObjectWithTag("ScaryDoor2").GetComponent<BoxCollider>().enabled = true;
            GameObject.FindGameObjectWithTag("ToyRoomLight").GetComponent<Light>().enabled = true;
            keystep2 = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            keystep2 = true;
        }
    }
}
