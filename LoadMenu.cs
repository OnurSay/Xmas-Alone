using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;
public class LoadMenu : MonoBehaviour {
    public GameObject c;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadGame()
    {
        c.SetActive(true);
        
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void Introduction()
    {
        SceneManager.LoadScene("Introduction");
    }


}
