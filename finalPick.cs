using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalPick : MonoBehaviour {
    public Animator animator;
    public static bool isEnd = false;
    public GameObject a;
    public GameObject orcs;
    public AudioSource Source;
    public AudioClip finalPickSound;
    bool isPlayed = false;
    float timer = 5f;
    bool isFinished = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 100 * Time.deltaTime, 0));
        if(isFinished == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 1.6)
            {
                a.SetActive(false);
                animator.SetBool("isPicked", false);
                isEnd = true;
                Destroy(gameObject);
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            orcs.SetActive(false);
            isFinished = true;
            animator.SetBool("isPicked", true);
            a.SetActive(true);
            if(isPlayed == false)
            {
                Source.PlayOneShot(finalPickSound);
                isPlayed = true;
            }
        }
    }
}
