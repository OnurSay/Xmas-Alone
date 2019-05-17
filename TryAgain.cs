using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class TryAgain : MonoBehaviour {
    private void Start()
    {
        controller = GameObject.FindObjectOfType<FirstPersonController>();
    }
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public void DoTryAgain()
    {
        Cursor.visible = false;
        
        controller.m_RunSpeed = 10;
        controller.m_WalkSpeed = 5;
        controller.m_Paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.LoadLevel(Application.loadedLevel);
    }
}