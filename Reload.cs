using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ReloadScene();
    }

    public void ReloadScene()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel("CardGame");
        }
    }
}