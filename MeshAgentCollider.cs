using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class MeshAgentCollider : MonoBehaviour {
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public GameObject Santa;
   public static bool keyStep1 = false;
    public static bool RoomEntry = false;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("FourthNoteTrigger").GetComponent<BoxCollider>().enabled = true;
            Santa.SetActive(true);
            RoomEntry = true;
            controller.m_RunSpeed = 0;
            controller.m_WalkSpeed = 0;
            keyStep1 = true;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
