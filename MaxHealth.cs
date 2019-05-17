using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHealth : MonoBehaviour {

    public AudioClip collectSound;
    public SimpleHealthBar healthBar1;
    public healthBar1 hb;
    public TextHints textHints;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            FullHealth(healthBar1);
            AudioSource.PlayClipAtPoint(collectSound, transform.position);        
            textHints.ShowHint("Health Recovered");                   
            Destroy(gameObject);
        }
    }

    public void FullHealth(SimpleHealthBar healthBar)
    {
        hb.currentHealth = hb.maxHealth;
        healthBar.UpdateBar(hb.currentHealth, hb.maxHealth);
    }

}
