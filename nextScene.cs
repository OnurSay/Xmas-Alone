﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextScene : MonoBehaviour {
    public GameObject c;
    public GameObject p;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            c.SetActive(true);
            p.GetComponent<LoadingScreenControl1>().LoadingScreenExample();
            
        }
    }
}
