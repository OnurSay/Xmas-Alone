using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
public class Message : MonoBehaviour {
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public bool Triggered = false;
    float timer = 30.0f;
    bool alreadyDestroyed = false;
    public TextHints hint1;
    public GameObject c;
    public GameObject L;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Triggered == true)
        {
            timer -= Time.deltaTime;
            controller.m_WalkSpeed = 0;
            controller.m_RunSpeed = 0;
            if (alreadyDestroyed == false) {
                GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
                alreadyDestroyed = true;
            }
            
            if (timer <= 29 && timer >= 28)
            {
                firstMessage();
            }else if (timer <= 24 && timer >= 23)
            {
                
                secondMessage();
            }
            else if (timer <= 18 && timer >= 17)
            {
                thirdMessage();
            }else if (timer <= 13 && timer >= 12)
            {
                fourthMessage();
            }else if (timer <= 6 && timer >= 5)
            {
                fifthMessage();
            }else if (timer <= 0)
            {
                SceneManager.LoadScene("CardGame");
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Triggered = true;

        }
    }

    void firstMessage()
    {
        hint1.ShowHint("Hello kiddo... Welcome to your f**kng best nightmare,");
    }

    void secondMessage()
    {
        hint1.ShowHint("I am the Wise. The keeper of the Maze...");
    }
    void thirdMessage()
    {
        hint1.ShowHint("If you want to pass me, you have to beat me...");
    }
    void fourthMessage()
    {
        hint1.ShowHint("in a card game. Yes, a card game. Are you surprised ?");
    }
    void fifthMessage()
    {
        hint1.ShowHint("Well then... Let's start ! If you lose, you will be PENALIZED !");
    }
    
}
