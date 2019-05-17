using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer1 : MonoBehaviour
{
    bool isPlayed = false;
    public AudioClip[] DarkHouse;
    public static AudioSource Source;
    // Use this for initialization
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (EntryCheck.Entry == true && isPlayed == false)
        {
            GameObject.Find("Cube (8)").GetComponent<AudioSource>().Stop();
            Source.PlayOneShot(DarkHouse[0]);
            isPlayed = true;
        }


    }
}
