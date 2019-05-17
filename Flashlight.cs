using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    // public static bool checkLight = false;
    private Light flash;

	// Use this for initialization
	void Start () {
        flash = GetComponent<Light>();

    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Fire2"))
        {
            if(flash.enabled == true)
            {
                flash.enabled = false;
            }
            else
            {
                flash.enabled = true;
            }
        }
    }
}
