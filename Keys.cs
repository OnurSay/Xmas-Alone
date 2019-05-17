using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour {

    public AudioClip collectSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            if(this.gameObject.tag == "BlueKey")
            {
                GameObject.FindGameObjectWithTag("BlueKeyImage").GetComponent<RawImage>().enabled = true;
            }
           else if (this.gameObject.tag == "GoldKey")
            {
                GameObject.FindGameObjectWithTag("GoldenKeyImage").GetComponent<RawImage>().enabled = true;
            }
            else if (this.gameObject.tag == "SilverKey")
            {
                GameObject.FindGameObjectWithTag("SilverKeyImage").GetComponent<RawImage>().enabled = true;
            }
            Destroy(gameObject);
        }
    }
}
