using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Inventory : MonoBehaviour {
    public static int SpriteNum = 0;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public GameObject panel;
    public GameObject BlueKey;
    public GameObject GoldenKey;
    public GameObject SecondNote;
    public static int silverKey;
    public static int goldenKey;
    public static int goldKey;
    public static int blueKey;
    public static bool BlueKeyGot = false;
    public static bool GoldenKeyGot = false;
    public static bool GoldKeyGot = false;
    public static bool SilverKeyGot = false;
    bool isInactive = false;
    float timer = 3.0f;
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        silverKey = 0;
        goldenKey = 0;
        blueKey = 0;
        controller = GameObject.FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
        //Cursor.lockState = CursorLockMode.None;
        if(isInactive == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameObject.FindGameObjectWithTag("Introducer").SetActive(false);
                isInactive = true;
            }
        }
        

    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "GoldenKey")
        {
            goldenKey++;
            GoldenKeyGot = true;
            GameObject.Destroy(GameObject.FindGameObjectWithTag("GoldenKey"));
            GameObject.FindGameObjectWithTag("GoldenKeyImage").GetComponent<RawImage>().enabled = true;
        }
        if (col.gameObject.tag == "GoldKey")
        {
            goldKey++;
            GoldKeyGot = true;
            GameObject.Destroy(GameObject.FindGameObjectWithTag("GoldKey"));
            GameObject.FindGameObjectWithTag("GoldenKeyImage").GetComponent<RawImage>().enabled = true;
        }

        if (col.gameObject.tag == "BlueKey")
        {
            BlueKeyGot = true;
            blueKey++;
            GameObject.Destroy(GameObject.FindGameObjectWithTag("BlueKey"));
            GameObject.FindGameObjectWithTag("BlueKeyImage").GetComponent<RawImage>().enabled = true;
            Debug.Log(blueKey);
        }
        if (col.gameObject.tag == "SilverKey")
        {
            silverKey++;
            SilverKeyGot = true;
           
        }
        if (col.gameObject.tag == "FirstNote")
        {
            SpriteNum = 1;
            panel.SetActive(true);
            controller.m_RunSpeed = 0;
            controller.m_WalkSpeed = 0;
            controller.m_Paused = true;
            Cursor.visible = true;
            Destroy(GameObject.FindGameObjectWithTag("FirstNote"));
            BlueKey.SetActive(true);
            SecondNote.SetActive(true);
            GameObject.FindGameObjectWithTag("RightDoor").GetComponent<BoxCollider>().enabled = true;



        }
        if (col.gameObject.tag == "SecondNote")
        {
            SpriteNum = 2;
            panel.SetActive(true);
            controller.m_RunSpeed = 0;
            controller.m_WalkSpeed = 0;
            controller.m_Paused = true;
            Cursor.visible = true;
            Destroy(GameObject.FindGameObjectWithTag("SecondNote"));


        }
        if (col.gameObject.tag == "ThirdNote")
        {
            SpriteNum = 3;
            panel.SetActive(true);
            controller.m_RunSpeed = 0;
            controller.m_WalkSpeed = 0;
            controller.m_Paused = true;
            Cursor.visible = true;
            Destroy(GameObject.FindGameObjectWithTag("ThirdNote"));


        }
        if (col.gameObject.tag == "FourthNote")
        {
            SpriteNum = 4;
            panel.SetActive(true);
            controller.m_RunSpeed = 0;
            controller.m_WalkSpeed = 0;
            controller.m_Paused = true;
            Cursor.visible = true;
            Destroy(GameObject.FindGameObjectWithTag("FourthNote"));


        }
        if (col.gameObject.tag == "UpperDoor")
        {
            GameObject.FindGameObjectWithTag("BlueKeyImage").GetComponent<RawImage>().enabled = false;
        }
        if(col.gameObject.tag == "LowerDoor")
        {
            GameObject.FindGameObjectWithTag("GoldenKeyImage").GetComponent<RawImage>().enabled = false;
        }
    }

   public void back()
    {
        panel.SetActive(false);
        controller.m_WalkSpeed = 30;
        controller.m_RunSpeed = 60;
        controller.m_Paused = false;
        Cursor.visible = false;
    }
    //void OnGUI()
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //}
}
