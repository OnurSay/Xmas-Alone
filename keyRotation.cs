using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyRotation : MonoBehaviour
{

    public float rotationSpeed = 100.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
