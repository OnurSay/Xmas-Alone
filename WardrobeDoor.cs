using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeDoor : MonoBehaviour {

    public Animator anim = null;

    float timer = 5.0f;
    bool isEnter = false;
	// Use this for initialization
	void Start () {
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(isEnter == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 2 && timer >= 1)
            {
                GameObject.FindGameObjectWithTag("BlueKey").GetComponent<CapsuleCollider>().enabled = true;
            }
            else if (Inventory.BlueKeyGot == false)
            {
               
                
                    GameObject.FindGameObjectWithTag("BlueKey").GetComponent<CapsuleCollider>().enabled = false;

               
            }
           if (timer <= 0)
            {
                anim.SetBool("IsOpen", false);
                isEnter = false;
                timer = 5.0f;
               
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

           
            anim.SetBool("IsOpen", true);
            isEnter = true;
        }
    }
}
