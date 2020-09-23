using System;
using UnityEngine;

public class Configurador : MonoBehaviour
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
            GameObject.FindGameObjectWithTag("Player1").transform.position = new Vector3(-18.27437f, -4.825582f,0);
            GameObject.FindGameObjectWithTag("Player2").transform.position = new Vector3(-18.27437f, 3.33f, 0);
            find = true;
        }
        catch (Exception)
        {
            
        }
    }
}
