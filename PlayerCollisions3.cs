﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions3 : MonoBehaviour {

    private bool doorIsOpen;
    private float doorTimer = 0.0f;
    public float doorOpenTime = 3.0f;
    private Animator anim;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;

    // Use this for initialization
    void Start()
    {

        anim = transform.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && doorIsOpen == false && Inventory.silverKey == 1)
        {
            Debug.Log("Geldim");
            OpenDoor(col.gameObject);
            GameObject.FindGameObjectWithTag("SilverKeyImage").GetComponent<RawImage>().enabled = false;
        }
    }

    void OpenDoor(GameObject door)
    {
        Debug.Log("Buraya da");
        doorIsOpen = true;
        door.GetComponent<AudioSource>().PlayOneShot(doorOpenSound);
        anim.Play("door_open");
        //Invoke("CloseDoor", doorOpenTime);
        StartCoroutine(CloseDoor(door, doorOpenTime));
    }

    IEnumerator CloseDoor(GameObject door, float delay)
    {
        yield return new WaitForSeconds(delay);
        doorIsOpen = false;
        door.GetComponent<AudioSource>().PlayOneShot(doorCloseSound);
        anim.Play("door_close");
    }

}