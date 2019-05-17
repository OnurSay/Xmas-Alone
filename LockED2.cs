using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockED2 : MonoBehaviour {
    GameObject Image;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Inventory.goldenKey == 1)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            
            

        }

	}
    
}
