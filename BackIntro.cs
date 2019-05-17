using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackIntro : MonoBehaviour {

    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {
        Cursor.visible = true;
    }

    // Use this for initialization
    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
