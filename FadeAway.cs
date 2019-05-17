using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeAway : MonoBehaviour {
    float duration = 5;
    public Text text;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if(Time.time > duration)
        {
            Destroy(gameObject);
        }

        Color mycolor = new Color(255f, 255f, 255f);
        float ratio = Time.time / duration;
        mycolor.a = Mathf.Lerp(1, 0, ratio);
        text.color = mycolor;
	}
}
