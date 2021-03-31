using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFase : MonoBehaviour
{

    private bool find;
    void Start()
    {
        find = false;
    }

    void Update()
    {
        if (find)
            return;
        try
        {
            GameObject.FindGameObjectWithTag("Player1").transform.position = new Vector3(-55, 11.229f);
            GameObject.FindGameObjectWithTag("Player2").transform.position = new Vector3(-55, -25.870f);
            find = true;
        }
        catch (Exception)
        {

        }
    }
}
