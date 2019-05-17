using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class TriggerZone : MonoBehaviour {
    public GameObject RoomLight;
    public GameObject ThirdNote;
    public TextHints textHints;
    bool Collision = false;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    float timer = 3.0f;
    // Use this for initialization
    void Start () {
        controller = GameObject.FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Collision == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                RoomLight.SetActive(true);
                ThirdNote.SetActive(true);
                timer = 3.0f;
                Collision = false;
                controller.m_WalkSpeed = 30;
                controller.m_RunSpeed = 60;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "RunnerZombie")
        {
            Debug.Log("Buradayım");
            controller.m_RunSpeed = 0;
            controller.m_WalkSpeed = 0;
            Destroy(GameObject.FindGameObjectWithTag("RunnerZombie"));
            Collision = true;
        }
        if (col.gameObject.tag == "SnowmanGreen")
        {
            //Debug.Log("here");
            //textHints.gameObject.SetActive(true);
            textHints.ShowHint("There is a door nearby.");
            //textHints.SendMessage("ShowHint","There is a door nearby.");
        }
    }
}

