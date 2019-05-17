using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class powPickup : MonoBehaviour {

    //public AudioClip collectSound;
    public TextHint textHints;
    public TextHint textHints2;
    public TextHint textHints3;
    public TextHint textHints4;
    public bool speedUp = false;
    public bool orcsGone = false;
    float timer = 0.0f;
    float timerForOrcs = 0.0f;
    string x;
    public GameObject Orc;
    public GameObject Orc1;
    public GameObject Orc2;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (speedUp == true)
        {
            timer += Time.deltaTime;
            x = timer.ToString();
            textHints2.ShowHint(x);
            if (timer >= 20)
            {
                speedUp = false;
                textHints.ShowHint("Normal Speed");
                gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
                gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 10;
                timer = 0.0f;
            }
        }

        if (orcsGone == true)
        {
            timerForOrcs += Time.deltaTime;
            x = timerForOrcs.ToString();
            textHints4.ShowHint(x);
            if (timerForOrcs >= 10)
            {
                orcsGone = false;
                textHints3.ShowHint("Monsters are here ");
                Orc.SetActive(true);
                Orc1.SetActive(true);
                Orc2.SetActive(true);
                timerForOrcs = 0.0f;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BlueGem")
        {
            speedUp = true;
            //AudioSource.PlayClipAtPoint(collectSound, transform.position);
            textHints.ShowHint("20s Speed Up");

            gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 10; 
            gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 15;

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "OrangeGem")
        {
            orcsGone = true;
            //AudioSource.PlayClipAtPoint(collectSound, transform.position);
            textHints3.ShowHint("10s no enemy ");
            
            Orc.SetActive(false);
            Orc1.SetActive(false);
            Orc2.SetActive(false);
            Destroy(col.gameObject);
        }

        

    }


}


  


