using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
  
    private Animator anim;
    public bool foundKid;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            
            anim.SetBool("foundKid", true);



        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("foundKid", false);
    }
}