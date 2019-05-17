using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockED : MonoBehaviour {
    public BoxCollider b = null;
	// Use this for initialization
	void Start () {
       b = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		


        if(Inventory.blueKey == 1 || Inventory.BlueKeyGot == true)
        {
            b.enabled = true;
            
        }
        else
        {
            b.enabled = false;
        }
	}
}
