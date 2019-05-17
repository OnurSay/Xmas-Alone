using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
    public float timer = 20f;
    public GameObject t1, t2, main,next;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 10)
        {
            t1.SetActive(false);
            t2.SetActive(true);
            
        }
        if(timer <= 0)
        {
            next.SetActive(true);
            main.SetActive(false);
        }
	}
}
