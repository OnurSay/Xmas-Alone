using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer2 : MonoBehaviour
{
    bool isPlayed = false;
    public AudioClip[] DarkHouse;
    AudioSource Source2;
    // Use this for initialization
    void Start()
    {
        Source2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MeshAgentCollider.RoomEntry == true && isPlayed == false)
        {
            MusicPlayer1.Source.Stop();
            Source2.PlayOneShot(DarkHouse[0]);
            isPlayed = true;
        }
    }

}
