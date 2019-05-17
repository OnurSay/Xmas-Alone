using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class JumpScare2 : MonoBehaviour {
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    float timer = 5.0f;
    public AudioClip BearClip;
    public AudioSource Source;
    public GameObject ScarryBear;
    bool alreadyPlayed = false;
    bool isEnter = false;
    // Use this for initialization
    void Start () {
        controller = GameObject.FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
		if(isEnter == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 3 &&  timer>=1.5f)
            {
                if (alreadyPlayed == false)
                {
                    ScarryBear.SetActive(true);
                    Source.PlayOneShot(BearClip);
                    alreadyPlayed = true;
                }
                
            }
            if (timer <= 0)
            {
                ScarryBear.SetActive(false);
                controller.m_WalkSpeed = 30;
                controller.m_RunSpeed = 60;
                isEnter = false;
                timer = 3.0f;
                this.GetComponent<BoxCollider>().enabled = false;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            controller.m_WalkSpeed = 0;
            controller.m_RunSpeed = 0;
            isEnter = true;
        }
    }
}
