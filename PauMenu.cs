using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class PauMenu : MonoBehaviour
    {
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public static bool GameIsPaused = false;
        public GameObject pauseMenuUI;
        public GameObject MainCam;
        public GameObject SecondCam;
        // Use this for initialization
        void Start()
        {

            Cursor.visible = false;
        controller = GameObject.FindObjectOfType<FirstPersonController>();
    }

        // Update is called once per frame
        void Update()
        {
        if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

        }

       public void Resume()
        {
            
            
            controller.m_Paused = false;
            Cursor.visible = false;
            pauseMenuUI.SetActive(false);
            MainCam.SetActive(true);
            SecondCam.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void Pause()
        {
            
            
            controller.m_Paused = true;
            Cursor.visible = true;
            pauseMenuUI.SetActive(true);
            MainCam.SetActive(false);
            SecondCam.SetActive(true);
            SecondCam.transform.rotation.Set(0, 0, 0, 0);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void LoadMenu()
        {

             
            controller.m_Paused = false;
             Time.timeScale = 1f;
             GameIsPaused = false;
             SceneManager.LoadScene("MainMenu");
        
        }

        public void QuitGame()
        {
             Application.Quit();
        }



    }
