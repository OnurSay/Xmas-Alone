using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardGame2 : MonoBehaviour
{

    public bool buttonClicked = false;
    public Button m_YourFirstButton;
    public static int count = 0;
    public static int userScore = 0;
    public static int opponentScore = 0;
    public  static bool isFinished = false;
    public static Text opponent;
    public static Text player;
    public static bool isWin = false;
    float timer = 0.1f;
    float timer2 = 3.0f;
    public GameObject a; //user has emperor
    public GameObject endLost; //end scene if the user loses
    public GameObject endDraw; //end scene if the scores are equal
    public GameObject endWin; //end scene if user wins
    public GameObject thirdRound;

    public GameObject Tc1;
    public GameObject Tc2;
    public GameObject Tc3;
    public GameObject Tc4;
    public GameObject Te;
    public GameObject Ts;
    public GameObject Tc5;
    public GameObject Tc6;
    public GameObject Tc7;
    public GameObject Tc8;
    public GameObject Tuc1;
    public GameObject Tuc2;
    public GameObject Tuc3;
    public GameObject Tuc4;
    public GameObject Tus;
    public GameObject Tuc5;
    public GameObject Tuc6;
    public GameObject Tuc7;
    public GameObject Tuc8;
    public GameObject Tue;
    public static GameObject[] TcardList1 = new GameObject[5]; //opponent has emperor
    public static GameObject[] TcardList2 = new GameObject[5]; //opponent has slave
    public static GameObject[] TcardList3 = new GameObject[5]; //user has slave
    public static GameObject[] TcardList4 = new GameObject[5]; //user has emperor

    public GameObject myPrefab;


    // Use this for initialization
    void Start()
    {
        //Debug.Log("Geçmişten gelen user score: " + CardGame.userScore);
        //Debug.Log("Geçmişten gelen opp score: " + CardGame.opponentScore);

        userScore = CardGame.userScore;
        opponentScore = CardGame.opponentScore;
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
        //when user has slave
        Debug.Log(TcardList3.Length);
        TcardList3[0] = Tuc1;
        TcardList3[1] = Tuc2;
        TcardList3[2] = Tuc3;
        TcardList3[3] = Tuc4;
        TcardList3[4] = Tus;

        //when user has emperor
        TcardList4[0] = Tuc5;
        TcardList4[1] = Tuc6;
        TcardList4[2] = Tuc7;
        TcardList4[3] = Tuc8;
        TcardList4[4] = Tue;

        //when opponent has emporer
        TcardList1[0] = Tc1;
        TcardList1[1] = Tc2;
        TcardList1[2] = Tc3;
        TcardList1[3] = Tc4;
        TcardList1[4] = Te;

        //when opponent has slave 
        TcardList2[0] = Tc5;
        TcardList2[1] = Tc6;
        TcardList2[2] = Tc7;
        TcardList2[3] = Tc8;
        TcardList2[4] = Ts;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Count is " + count);
        if (count == 5)
        {
            timer = timer - Time.deltaTime;

            Destroy(GameObject.FindWithTag("TRS"));
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
            //ClickToPlay.roundOnePlaying = true;
            //thirdRound.SetActive(true);


            if (opponentScore >= userScore)
            {
                isFinished = true;
                endLost.SetActive(true);
                isWin = false;
            }
          
            else if (userScore > opponentScore)
            {
                isFinished = true;
                //Debug.Log("KAZANDIN");
                GameObject.FindWithTag("smoke").SetActive(false);
                endWin.SetActive(true);
                isWin = true;
            }


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

