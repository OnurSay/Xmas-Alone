using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteChanger : MonoBehaviour {
    public Sprite[] a;
    Image Actual;
	// Use this for initialization
	void Start () {
        Actual = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Inventory.SpriteNum == 1)
        {
            Actual.sprite = a[0];
          
        }else if (Inventory.SpriteNum == 2)
        {
            Actual.sprite = a[1];

        }
        else if (Inventory.SpriteNum == 3)
        {
            Actual.sprite = a[2];

        }
        else if (Inventory.SpriteNum == 4)
        {
            Actual.sprite = a[3];

        }
    }
}
