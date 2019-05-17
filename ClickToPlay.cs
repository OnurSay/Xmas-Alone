using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickToPlay : MonoBehaviour
{
    public AudioClip musicClip;
    public AudioSource musicSource;
    public AudioClip beginClip;
    public AudioSource beginSource;
    public float timer = 1.5f;
    public float timer2 = 3f;
    public bool rotation = false;
    public bool rotation2 = false;
    bool isDone = false;
    bool IsPlaying = false;
    public GameObject element;
    public GameObject element2;
    public Text pscore;
    public static bool roundOnePlaying = true;
    public bool clickable = true;
    bool playable = true;
    bool destroyed = false;
    float animTime = 1.5f;
    float animTime2 = 1.5f;
    bool done = true;
    bool done2 = true;

    private void Start()
    {
        musicSource.clip = musicClip;
        beginSource.clip = beginClip;
        if (CardGame.count == 0)
        {
            beginSource.Play();

        }
    }

    private void Update()
    {
        Debug.Log("Anim time 2 : " + animTime2);
        animTime = animTime - Time.deltaTime;
        if (animTime > 0)
        {
            if(isDone == false)
            {
                for (int i = 0; i < CardGame.cardList3.Length; i++)
                {
                    CardGame.cardList3[i].GetComponent<BoxCollider>().enabled = false;
                }
                isDone = true;
            }
           
        }

        else if (animTime <= 0 && done)
        {
            for (int i = 0; i < CardGame.cardList3.Length; i++)
            {
                if (CardGame.cardList3[i] == null)
                {
                    continue;
                }
                CardGame.cardList3[i].GetComponent<BoxCollider>().enabled = true;
            }
            done = false;
        }
        
      
        if (!roundOnePlaying)
        {
            Debug.Log("ANIMASYON 2 IS HERE");
            animTime2 = animTime2 - Time.deltaTime;
            if (animTime2 > 0)
            {
                
                for (int i = 0; i < CardGame.cardList4.Length; i++)
                {
                    CardGame.cardList4[i].GetComponent<BoxCollider>().enabled = false;
                }
            }

            else if (animTime2 <= 0 && done2)
            {
                for (int i = 0; i < CardGame.cardList4.Length; i++)
                {
                    if (CardGame.cardList4[i] == null)
                    {
                        continue;
                    }
                    CardGame.cardList4[i].GetComponent<BoxCollider>().enabled = true;
                }
                done2 = false;
            }
        }

        //Debug.Log("the value of destroyed is " + destroyed);
        //Debug.Log(CardGame.count);
        //Debug.Log(roundOnePlaying);
        //Debug.Log(timer);
        if (CardGame.count == 5)
        {
            roundOnePlaying = false;
        }

        if (rotation == true || !roundOnePlaying)
        {

            if (timer >= 0)
            {
                timer -= Time.deltaTime;

            }
            else if (timer <= 0 || !roundOnePlaying)
            {
                if (roundOnePlaying && CardGame.count != 5)
                {
                    //Debug.Log("round one: " + gameObject.tag + " vs " + element.tag);
                    if (gameObject.tag == "citizen" && element.tag == "citizen")
                    {
                        //Debug.Log("Citizen vs Citizen");
                        musicSource.Play();
                    }
                    if (gameObject.tag == "citizen" && element.tag == "emperor")
                    {
                        //Debug.Log("Citizen vs Emperor");
                        CardGame.opponentScore++;
                        CardGame.count = 5;
                        musicSource.Play();
                    }
                    if (gameObject.tag == "slave" && element.tag == "emperor")
                    {
                        //Debug.Log("Slave vs Emperor");
                        CardGame.userScore += 3;
                        CardGame.count = 5;
                        musicSource.Play();

                    }
                    if (gameObject.tag == "slave" && element.tag == "citizen")
                    {
                        //Debug.Log("Slave vs Citizen");
                        CardGame.opponentScore++;
                        CardGame.count = 5;
                        musicSource.Play();
                    }
                }
                else if (timer <= 0 && !roundOnePlaying && element2 != null && CardGame.count != 10)
                {
                    //Debug.Log("SELAM DOSTUM" + element2.tag);
                    //Debug.Log("round two: " + gameObject.tag + " vs " + element2.tag);
                    if (gameObject.tag == "citizen" && element2.tag == "citizen")
                    {
                        //Debug.Log("Citizen vs Citizen");
                        musicSource.Play();


                        //CardGame.opponentScore++;

                    }
                    else if (gameObject.tag == "emperor" && element2.tag == "citizen")
                    {
                        //Debug.Log("!!! Citizen vs Emperor !!!");
                        CardGame.userScore++;
                        CardGame.count = 10;
                        musicSource.Play();

                    }
                    else if (gameObject.tag == "emperor" && element2.tag == "slave")
                    {
                        //Debug.Log("Slave vs Emperor");
                        CardGame.opponentScore += 3;
                        musicSource.Play();
                        CardGame.count = 10;


                    }
                    else if (gameObject.tag == "citizen" && element2.tag == "slave")
                    {
                        //Debug.Log("Slave vs Citizen");
                        CardGame.userScore++;
                        CardGame.count = 10;
                        musicSource.Play();


                    }
                    else
                    {
                        //Debug.Log("Pairing Failed");
                        //Debug.Log("gameObject.tag is " + gameObject.tag);
                        //Debug.Log("element2.tag is " + element2.tag);
                    }
                }

                if (roundOnePlaying)
                {
                    System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>(CardGame.cardList1);
                    list.Remove(element);
                    CardGame.cardList1 = list.ToArray();
                    rotation = false;


                }
                else if (!roundOnePlaying)
                {
                    //Debug.Log("CHECKING ELSE");
                    System.Collections.Generic.List<GameObject> list2 = new System.Collections.Generic.List<GameObject>(CardGame.cardList2);
                    list2.Remove(element2);
                    CardGame.cardList2 = list2.ToArray();

                }
                GameObject.FindWithTag("pscore").GetComponent<Text>().text = "Player Score: " + CardGame.userScore;
                GameObject.FindWithTag("oscore").GetComponent<Text>().text = "Opponent Score: " + CardGame.opponentScore;

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
            //CardGame.count++;
            int rnd = Random.Range(0, CardGame.cardList1.Length);
            element = CardGame.cardList1[rnd];
            for (int i = 0; i < CardGame.cardList3.Length; i++)
            {
                if (CardGame.cardList3[i] == null)
                {
                    continue;
                }
                CardGame.cardList3[i].GetComponent<BoxCollider>().enabled = false;
            }
            System.Collections.Generic.List<GameObject> Userlist = new System.Collections.Generic.List<GameObject>(CardGame.cardList3);
            Userlist.Remove(gameObject);
            CardGame.cardList3 = Userlist.ToArray();
            element.transform.Translate((float)(1.15 - element.transform.position.x), (float)-4.4, 0);
            Invoke("rotateElement", 1.5f);//this will happen after 1.5 seconds
            Invoke("destroyIt", 3.5f);//this will happen after 2 seconds


        }

        if (!roundOnePlaying)
        {
            Debug.Log("selam round2");
            gameObject.transform.Translate(gameObject.transform.position.x + 1, (float)4.5, 0);
            //Destroy(gameObject);
            //CardGame.count++;
            int rnd = Random.Range(0, CardGame.cardList2.Length);
            element2 = CardGame.cardList2[rnd];
            for (int i = 0; i < CardGame.cardList4.Length; i++)
            {
                if (CardGame.cardList4[i] == null)
                {
                    continue;
                }
                CardGame.cardList4[i].GetComponent<BoxCollider>().enabled = false;
            }
            System.Collections.Generic.List<GameObject> Userlist2 = new System.Collections.Generic.List<GameObject>(CardGame.cardList4);
            Userlist2.Remove(gameObject);
            CardGame.cardList4 = Userlist2.ToArray();
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
        for (int i = 0; i < CardGame.cardList3.Length; i++)
        {
            Debug.Log("Cards TAG : " + CardGame.cardList3[i].tag);
            CardGame.cardList3[i].GetComponent<BoxCollider>().enabled = true;
        }


    }
    private void destroyIt2()
    {
        Destroy(gameObject);
        Destroy(element2);
        for (int i = 0; i < CardGame.cardList4.Length; i++)
        {
            Debug.Log("Cards TAG : " + CardGame.cardList4[i].tag);
            CardGame.cardList4[i].GetComponent<BoxCollider>().enabled = true;
        }
    }
}