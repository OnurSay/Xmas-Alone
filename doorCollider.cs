using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCollider : MonoBehaviour {
    private Animator anim = null;
    public float closeTime = 5.0f;
    private bool isOpen = false;
    public AudioClip OpenSound, CloseSound;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
       
	}
	
	// Update is called once per frame
	void Update () {


        if (isOpen == true)
        {
            
            closeTime -= Time.deltaTime;
            if(closeTime <= 0)
            {
                
                isOpen = false;
                anim.SetBool("open", false);
                GetComponent<AudioSource>().PlayOneShot(CloseSound);
                closeTime = 5.0f;

            } 
        } 
	}

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(OpenSound);
        
        if (other.tag == "Player" || other.tag =="RunnerZombie")
        {
            isOpen = true;
            anim.SetBool("open", true);
        }
       
    }

   
}
