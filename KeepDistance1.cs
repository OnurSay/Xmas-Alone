using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance1 : MonoBehaviour {
    public Transform player;
    public float desiredDistance;
    public AudioSource Source;
    public AudioClip Roar;
    float timer = 2.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var offset = this.transform.position - player.position;
        if(offset.sqrMagnitude < desiredDistance * desiredDistance)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Source.PlayOneShot(Roar);
                timer = 2.0f;
            }
            
        }
	}
}
