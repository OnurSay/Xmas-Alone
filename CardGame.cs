using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CardGame : MonoBehaviour
{
    public bool buttonClicked = false;
    public Button m_YourFirstButton;
    public static int count = 0;
    public static int userScore = 0;
    public static int opponentScore = 0;
    public static Text opponent;
    public static Text player;
    float timer = 0.1f;
    float timer2 = 3.0f;
    public GameObject a; //user has emperor
    public GameObject endLost; //end scene if the user loses
    public GameObject endDraw; //end scene if the scores are equal
    public GameObject endWin; //end scene if user wins
    public GameObject thirdRound;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject e;
    public GameObject s;
    public GameObject c5;
    public GameObject c6;
    public GameObject c7;
    public GameObject c8;
    public GameObject uc1;
    public GameObject uc2;
    public GameObject uc3;
    public GameObject uc4;
    public GameObject us;
    public GameObject uc5;
    public GameObject uc6;
    public GameObject uc7;
    public GameObject uc8;
    public GameObject ue;
    public static GameObject[] cardList1 = new GameObject[5]; //opponent has emperor
    public static GameObject[] cardList2 = new GameObject[5]; //opponent has slave
    public static GameObject[] cardList3 = new GameObject[5]; //user has slave
    public static GameObject[] cardList4 = new GameObject[5]; //user has emperor

    public GameObject myPrefab;


    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
        //when user has slave
        cardList3[0] = uc1;
        cardList3[1] = uc2;
        cardList3[2] = uc3;
        cardList3[3] = uc4;
        cardList3[4] = us;

        //when user has emperor
        cardList4[0] = uc5;
        cardList4[1] = uc6;
        cardList4[2] = uc7;
        cardList4[3] = uc8;
        cardList4[4] = ue;

        //when opponent has emporer
        cardList1[0] = c1;
        cardList1[1] = c2;
        cardList1[2] = c3;
        cardList1[3] = c4;
        cardList1[4] = e;

        //when opponent has slave 
        cardList2[0] = c5;
        cardList2[1] = c6;
        cardList2[2] = c7;
        cardList2[3] = c8;
        cardList2[4] = s;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Count is " + count);
        if (count == 5)
        {
            timer = timer - Time.deltaTime;

            Destroy(GameObject.FindWithTag("FRS"));
        }
        if (timer <= 0)
        {
            a.SetActive(true);
        }

        if (count == 10)
        {
            timer2 = timer2 - Time.deltaTime;

        }
        if (timer2 <= 0)
        {
            a.SetActive(false);
            GameObject.FindWithTag("bg1").SetActive(false);
            //ClickToPlay.roundOnePlaying = true;
            GameObject.FindWithTag("bg2").SetActive(true);
            thirdRound.SetActive(true);
            CardGame2.userScore = userScore;
            CardGame2.opponentScore = opponentScore;


            //if (opponentScore > userScore)
            //{
            //    endLost.SetActive(true);
            //}
            //else if (userScore == opponentScore)
            //{
            //    endDraw.SetActive(true);
            //}
            //else if (userScore > opponentScore)
            //{
            //    Debug.Log("KAZANDIN");
            //    GameObject.FindWithTag("smoke").SetActive(false);
            //    endWin.SetActive(true);  
            //}


            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            //Start();
            //initTemp.SetActive(true);
            //GameObject go = (GameObject)Instantiate(myPrefab);
        }

    }
    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        buttonClicked = true;
        Destroy(GameObject.FindWithTag("helppanel"));

    }




}
