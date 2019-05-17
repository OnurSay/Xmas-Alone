using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
public class healthBar : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Hit;
    public SimpleHealthBar healthBar1;
    public float currentHealth = 100;
    public float maxHealth = 100;
    public GameObject C, L;
    public GameObject[] All;
    //public float damage = 10; 
    //public bool DamageTaken = false;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public float time = 3.0f;
    public float timer = 2f;
    public float timeReset = 0.0f;
    public bool dmgTaken;
    GameObject orc;
    public GameObject healthcan;
    public GameObject diecan;
    bool alreadyInside = false;
    // Use this for initialization
    void Start()
    {
        if (CardGame2.isWin == false)
        {
            currentHealth = 25;

        }else if(CardGame2.isWin == true)
        {
            currentHealth = maxHealth;
        }
        Cursor.lockState = CursorLockMode.None;
        controller = GameObject.FindObjectOfType<FirstPersonController>();
        dmgTaken = false;
        healthBar1.UpdateBar(currentHealth, maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
       
        if (dmgTaken)
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = false;
            time -= Time.deltaTime;
            if (time <= 0)
            {

                GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = true;
                dmgTaken = false;
                time = 3.0f;
            }
        }
        if (currentHealth <= 0)
        {
            if (alreadyInside == false)
            {
                Pause();
                alreadyInside = true;
            }
        }


        if(finalPick.isEnd == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {

                //for(int i = 0; i < All.Length; i++)
                //{
                //    All[i].SetActive(false);
                //}
                //C.SetActive(true);
                //L.GetComponent<LoadingScreenControl4>().LoadingScreenExample();

                SceneManager.LoadScene("EndScene");
                finalPick.isEnd = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar1.UpdateBar(currentHealth, maxHealth);
    }

    public void FullHealth(SimpleHealthBar healthBar)
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Monster" && dmgTaken == false)
        {
            TakeDamage(25);
            Source.PlayOneShot(Hit);
            dmgTaken = true;
        }

    }

    void Pause()
    {
        Cursor.visible = true;
        healthcan.SetActive(false);
        diecan.SetActive(true);
        
        controller.m_RunSpeed = 0;
        controller.m_WalkSpeed = 0;
        controller.m_Paused = true;
    }

    

}



