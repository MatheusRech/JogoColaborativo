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
            GameObject.FindGameObjectWithTag("Player1").transform.position = new Vector3(-55f, 11.229f, 0f);
            GameObject.FindGameObjectWithTag("Player2").transform.position = new Vector3(-55f, -25.870f, 0f);
            gameObject.GetComponent<cameraManager>().disabilitarCamera(true);
            find = true;
        }
        catch (Exception)
        {

        }
    }
}
