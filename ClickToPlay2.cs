using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToPlay2 : MonoBehaviour
{

    public AudioClip musicClip;
    public AudioSource musicSource;
    public AudioClip beginClip;
    public AudioSource beginSource;
    public float timer = 1.5f;
    public float timer2 = 3f;
    public bool rotation = false;
    public bool rotation2 = false;
    bool IsPlaying = false;
    public GameObject element;
    public GameObject element2;
    public Text pscore;
    static bool roundOnePlaying = true;
    public bool clickable = true;
    bool playable = true;
    bool destroyed = false;
    float animTime = 1.5f;
    bool done = true;
    bool isDone = false;
    private void Start()
    {
        //musicSource.clip = musicClip;
        //beginSource.clip = beginClip;

        //if (CardGame2.count == 0)
        //{
        //    beginSource.Play();

        //}
    }

    private void Update()
    {
        if (roundOnePlaying)
        {
            animTime -= Time.deltaTime;
            if (animTime > 0)
            {
                if (isDone == false)
                {
                    for (int i = 0; i < CardGame2.TcardList3.Length; i++)
                    {
                        CardGame2.TcardList3[i].GetComponent<BoxCollider>().enabled = false;
                    }
                    isDone = true;
                }
               
            }

            else if (animTime <= 0 && done)
            {
                for (int i = 0; i < CardGame2.TcardList3.Length; i++)
                {
                    if (CardGame2.TcardList3[i] == null)
                    {
                        continue;
                    }
                    CardGame2.TcardList3[i].GetComponent<BoxCollider>().enabled = true;
                }
                done = false;
                animTime = 1.5f;
            }
            
        }
        
        if (!roundOnePlaying)
        {
            animTime -= Time.deltaTime;
            Debug.Log("BURAYA DA GELDİM DAYI **************************************************");
            if (animTime > 0)
            {
                if (isDone == false)
                {
                    for (int i = 0; i < CardGame2.TcardList4.Length; i++)
                    {
                        CardGame2.TcardList4[i].GetComponent<BoxCollider>().enabled = false;
                    }
                    isDone = true;
                }
                done = true;
               

            }

            else if (animTime <= 0 && done)
            {
                for (int i = 0; i < CardGame2.TcardList4.Length; i++)
                {
                    if (CardGame2.TcardList4[i] == null)
                    {
                        continue;
                    }
                    CardGame2.TcardList4[i].GetComponent<BoxCollider>().enabled = true;
                }
                done = false;
                animTime = 1.5f;
            }
           
        }


        CardGame.opponentScore = CardGame2.opponentScore;
        CardGame.userScore = CardGame2.userScore;
        //Debug.Log("the value of destroyed is " + destroyed);
        //Debug.Log(CardGame2.count);
        //Debug.Log(roundOnePlaying);
        //Debug.Log(timer);
        if (CardGame2.count == 5)
        {
            roundOnePlaying = false;
        }
        Debug.Log("timer is : " + timer);
        Debug.Log("element2 : " + element2);
        Debug.Log("roundoneplaying is : " + roundOnePlaying);
        Debug.Log("cardgame2.count is : " + CardGame2.count);
        if (rotation == true || !roundOnePlaying)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;

            }
            else if (timer <= 0 || !roundOnePlaying)
            {

                if (roundOnePlaying && CardGame2.count != 5)
                {
                    if (gameObject.tag == "citizen" && element.tag == "citizen")
                    {
                        //Debug.Log("Citizen vs Citizen");
                        musicSource.Play();
                    }
                    if (gameObject.tag == "citizen" && element.tag == "emperor")
                    {
                        //Debug.Log("Citizen vs Emperor");
                        CardGame2.opponentScore++;
                        CardGame2.count = 5;
                        musicSource.Play();
                    }
                    if (gameObject.tag == "slave" && element.tag == "emperor")
                    {
                        //Debug.Log("Slave vs Emperor");
                        CardGame2.userScore += 3;
                        CardGame2.count = 5;
                        musicSource.Play();

                    }
                    if (gameObject.tag == "slave" && element.tag == "citizen")
                    {
                        //Debug.Log("Slave vs Citizen");
                        CardGame2.opponentScore++;
                        CardGame2.count = 5;
                        musicSource.Play();
                    }
                }


                else if (timer <= 0 && !roundOnePlaying && element2 != null && CardGame2.count != 10)
                {
                    Debug.Log("FINALLY I AM IN THAT STATEMENT");

                    //Debug.Log("SELAM DOSTUM" + element2.tag);
                    Debug.Log("round two: " + gameObject.tag + " vs " + element2.tag);
                    if (gameObject.tag == "citizen" && element2.tag == "citizen")
                    {
                        //Debug.Log("Citizen vs Citizen");
                        musicSource.Play();


                        //CardGame2.opponentScore++;

                    }
                    else if (gameObject.tag == "emperor" && element2.tag == "citizen")
                    {
                        //Debug.Log("!!! Citizen vs Emperor !!!");
                        CardGame2.userScore++;
                        CardGame2.count = 10;
                        musicSource.Play();

                    }
                    else if (gameObject.tag == "emperor" && element2.tag == "slave")
                    {
                        //Debug.Log("Slave vs Emperor");
                        CardGame2.opponentScore += 3;
                        musicSource.Play();
                        CardGame2.count = 10;


                    }
                    else if (gameObject.tag == "citizen" && element2.tag == "slave")
                    {
                        //Debug.Log("Slave vs Citizen");
                        CardGame2.userScore++;
                        CardGame2.count = 10;
                        musicSource.Play();


                    }
                    else
                    {
                        Debug.Log("Pairing Failed");
                        Debug.Log("gameObject.tag is " + gameObject.tag);
                        Debug.Log("element2.tag is " + element2.tag);
                    }
                }

                if (roundOnePlaying)
                {
                    System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>(CardGame2.TcardList1);
                    list.Remove(element);
                    CardGame2.TcardList1 = list.ToArray();
                    rotation = false;


                }
                else if (!roundOnePlaying)
                {
                    //Debug.Log("CHECKING ELSE");
                    System.Collections.Generic.List<GameObject> list2 = new System.Collections.Generic.List<GameObject>(CardGame2.TcardList2);
                    list2.Remove(element2);
                    CardGame2.TcardList2 = list2.ToArray();

                }
                GameObject.FindWithTag("pscore").GetComponent<Text>().text = "Player Score: " + CardGame2.userScore;
                GameObject.FindWithTag("oscore").GetComponent<Text>().text = "Opponent Score: " + CardGame2.opponentScore;

            }
        }
    }
    private void OnMouseDown()
    {


        playable = false;
        if (roundOnePlaying)
        {

            gameObject.transform.Translate(gameObject.transform.position.x + 1, (float)4.5, 0);
            //Destroy(gameObject);
            //CardGame2.count++;
            int rnd = Random.Range(0, CardGame2.TcardList1.Length);
            element = CardGame2.TcardList1[rnd];
            for (int i = 0; i < CardGame2.TcardList3.Length; i++)
            {
                if (CardGame2.TcardList3[i] == null)
                {
                    continue;
                }
                CardGame2.TcardList3[i].GetComponent<BoxCollider>().enabled = false;
            }
            System.Collections.Generic.List<GameObject> Userlist = new System.Collections.Generic.List<GameObject>(CardGame2.TcardList3);
            Userlist.Remove(gameObject);
            CardGame2.TcardList3 = Userlist.ToArray();
            element.transform.Translate((float)(1.15 - element.transform.position.x), (float)-4.4, 0);
            Invoke("rotateElement", 1.5f);//this will happen after 1.5 seconds
            Invoke("destroyIt", 3.5f);//this will happen after 2 seconds


        }

        if (!roundOnePlaying)
        {
            Debug.Log("CardGame2.TcardList2 array length :  " + CardGame2.TcardList2.Length);
            gameObject.transform.Translate(gameObject.transform.position.x + 1, (float)4.5, 0);
            //Destroy(gameObject);
            //CardGame2.count++;
            int rnd = Random.Range(0, CardGame2.TcardList2.Length);
            element2 = CardGame2.TcardList2[rnd];
            for (int i = 0; i < CardGame2.TcardList4.Length; i++)
            {
                if (CardGame2.TcardList4[i] == null)
                {
                    continue;
                }
                CardGame2.TcardList4[i].GetComponent<BoxCollider>().enabled = false;
            }
            System.Collections.Generic.List<GameObject> Userlist2 = new System.Collections.Generic.List<GameObject>(CardGame2.TcardList4);
            Userlist2.Remove(gameObject);
            CardGame2.TcardList4 = Userlist2.ToArray();
            element2.transform.Translate((float)(1.15 - element2.transform.position.x), (float)-4.4, 0);
            Invoke("rotateElement2", (float)1.5);//this will happen after 1.5 seconds
            Invoke("destroyIt2", (float)3.5);//this will happen after 2 seconds
        }



    }

    private void rotateElement()
    {

        rotation = true;
        element.transform.Rotate(0, 180, 0);

    }
    private void rotateElement2()
    {

        rotation2 = true;
        element2.transform.Rotate(0, 180, 0);

    }
    private void destroyIt()
    {
        Destroy(gameObject);
        Destroy(element);
        for (int i = 0; i < CardGame2.TcardList3.Length; i++)
        {
            Debug.Log("Cards TAG : " + CardGame2.TcardList3[i].tag);
            CardGame2.TcardList3[i].GetComponent<BoxCollider>().enabled = true;
        }


    }
    private void destroyIt2()
    {
        Destroy(gameObject);
        Destroy(element2);
        for (int i = 0; i < CardGame2.TcardList4.Length; i++)
        {
            Debug.Log("Cards TAG : " + CardGame2.TcardList4[i].tag);
            CardGame2.TcardList4[i].GetComponent<BoxCollider>().enabled = true;
        }
    }
}