using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour {
    public Transform player;
    public float desiredDistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var offset = this.transform.position - player.position;
        if(offset.sqrMagnitude < desiredDistance * desiredDistance)
        {
            this.transform.position = this.transform.position + offset.normalized * (desiredDistance - offset.magnitude);
        }
	}
}
