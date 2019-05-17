using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {
    float timer = 3.0f;
    public GameObject c;
    public GameObject L;
    public GameObject[] All;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	        if(CardGame2.isFinished == true)
        {
            
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                for(int i = 0; i< All.Length; i++)
                {
                    All[i].SetActive(false);
                }
                c.SetActive(true);
                L.GetComponent<LoadingScreenControl3>().LoadingScreenExample();
            }

        }	
	}
}
