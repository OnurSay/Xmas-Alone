using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDissapearer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && Inventory.blueKey == 1)
        {
            GameObject.FindGameObjectWithTag("BlueKeyImage").GetComponent<RawImage>().enabled = false;
        }
    }
}
