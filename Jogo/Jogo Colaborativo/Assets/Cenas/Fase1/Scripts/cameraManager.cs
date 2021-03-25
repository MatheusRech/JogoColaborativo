using System;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject gameObjectCamera;
    private Camera objetoCamera;

    private Vector3 player1;
    private Vector3 player2;

    private Vector3 cameraPosition;

    private bool disable;


    void Start()
    {
        objetoCamera = gameObjectCamera.GetComponent<Camera>();
        cameraPosition = gameObjectCamera.transform.position;
        disable = false;
    }

    void Update()
    {
        if (disable)
        {
            return;
        }


        try
        {
            player1 = GameObject.FindGameObjectWithTag("Player1").transform.position;
            player2 = GameObject.FindGameObjectWithTag("Player2").transform.position;
        }
        catch (Exception)
        {
            return;
        }


        //  Distancia da camera
        float sizex = player1.x - player2.x;

        float sizey = player1.y - player2.y;
        float size = sizex + sizey;

        if (size < 0)
            size = (sizex * -1) + (sizey * -1);

        objetoCamera.orthographicSize = size;

        if (objetoCamera.orthographicSize > 21.6)
        {
            objetoCamera.orthographicSize = 21.6f;
        }else if(objetoCamera.orthographicSize < 10)
        {
            objetoCamera.orthographicSize = 10;
        }


        //  Posição X da camera
        if(player1.x > player2.x)
        {
            if(player2.x < 0 && player1.x < 0)
            {
                cameraPosition.x = (player1.x - player2.x) / 2;
            }
            else
            {
                cameraPosition.x = (player1.x + player2.x) / 2;
            }
            
        }
        else
        {
            if (player2.x < 0 && player1.x < 0)
            {
                cameraPosition.x = (player2.x - player1.x) / 2;
            }
            else
            {
                
                cameraPosition.x = (player2.x + player1.x) / 2;
            }
        }


        //  Posição Y da camera
        if (player1.y > player2.y)
        {
            if (player2.y < 0 && player1.y < 0)
            {
                cameraPosition.y = (player1.y - player2.y) / 2;
            }
            else
            {
                cameraPosition.y = (player1.y + player2.y) / 2;
            }

        }
        else
        {
            if (player2.y < 0 && player1.y < 0)
            {
                cameraPosition.y = (player2.y - player1.y) / 2;
            }
            else
            {

                cameraPosition.y = (player2.y + player1.y) / 2;
            }
        }

        gameObjectCamera.transform.position = cameraPosition;

    }

    public void disabilitarCamera(bool disable)
    {
        this.disable = disable;
    }
}
