using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour {
    public GameObject a;
    public AudioSource Source;
    public AudioClip Chase;
    bool alreadyPlayed = false;
    public float timer = 110.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(alreadyPlayed == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                alreadyPlayed = false;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("girdi");
        if (other.gameObject.tag == "Player")
        {
            if(alreadyPlayed == false)
            {
                Source.PlayOneShot(Chase);
                alreadyPlayed = true;
            }
            
            a.SetActive(true);
        }
    }
}
