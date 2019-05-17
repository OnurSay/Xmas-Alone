using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JumpScare : MonoBehaviour {
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public AudioClip jumpscare;
    public AudioClip jumpscare2;
    public AudioClip jumpscare3;
    public static bool dayiGeldi;
    bool alreadyPlayed = false;
    bool alreadyPlayed2 = false;
    bool alreadyPlayed3 = false;
    float timer = 11.4f;
    public GameObject ChildLaugher;
    bool isTriggered = false;
    public GameObject[] array1 = new GameObject[5];
    // Use this for initialization
    void Start () {
        controller = GameObject.FindObjectOfType<FirstPersonController>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isTriggered)
        {
            timer -= Time.deltaTime;
            if (!alreadyPlayed)
            {
                GameObject.FindGameObjectWithTag("ScaryDoor").GetComponent<BoxCollider>().enabled = false;
                GetComponent<AudioSource>().PlayOneShot(jumpscare);
                alreadyPlayed = true;
            }
            
            if (timer <= 8 && timer >= 7)
            {
              //  GameObject.FindGameObjectWithTag("JumpZom").SetActive(true);
                array1[0].SetActive(true);
               
            }
            else if(timer <7 && timer >= 6){
                //  GameObject.FindGameObjectWithTag("JumpZom").SetActive(true);
                array1[0].SetActive(false);
                
            }
            else if (timer <= 4 && timer >= 3)
            {
                if (!alreadyPlayed2)
                {
                    GetComponent<AudioSource>().PlayOneShot(jumpscare2);
                    alreadyPlayed2 = true;
                }
                dayiGeldi = true;
                array1[1].SetActive(true);
                array1[2].SetActive(true);

            }
            else if (timer < 3 && timer >= 2)
            {
                array1[2].SetActive(false);
                array1[1].SetActive(false);
               
            }
            else if (timer <= 2 && timer >= 1)
            {
                if (!alreadyPlayed3)
                {
                    GetComponent<AudioSource>().PlayOneShot(jumpscare3);
                    alreadyPlayed3 = true;
                }
                array1[2].SetActive(true);
                array1[1].SetActive(true);
                array1[3].SetActive(true);
                
            }
            else if (timer <= 0)
            {
                Debug.Log("Girdim Abe");
                controller.m_WalkSpeed = 30;
                controller.m_RunSpeed = 60;
                GameObject.FindGameObjectWithTag("JumpScare").GetComponent<BoxCollider>().enabled = false;
                GameObject.FindGameObjectWithTag("ScaryDoor").GetComponent<BoxCollider>().enabled = true;
                timer = 10.0f;
                isTriggered = false;
                
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ChildLaugher.GetComponent<AudioSource>().Stop();
            isTriggered = true;
            controller.m_WalkSpeed = 0;
            controller.m_RunSpeed = 0;
        }
    }
}

