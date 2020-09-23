using System;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject camera;
    private Camera objetoCamera;

    private Vector3 player1;
    private Vector3 player2;

    private Vector3 cameraPosition;


    void Start()
    {
        objetoCamera = camera.GetComponent<Camera>();
        cameraPosition = camera.transform.position;

    }

    void Update()
    {
        try
        {
            player1 = GameObject.FindGameObjectWithTag("Player1").transform.position;
            player2 = GameObject.FindGameObjectWithTag("Player2").transform.position;
        }
        catch (Exception)
        {

        }

        float size = player1.x - player2.x;

        if (size < 0)
            size = size * -1;

        objetoCamera.orthographicSize = size;

        if (objetoCamera.orthographicSize > 21.6)
        {
            objetoCamera.orthographicSize = 21.6f;
        }else if(objetoCamera.orthographicSize < 10)
        {
            objetoCamera.orthographicSize = 10;
        }

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

        camera.transform.position = cameraPosition;

    }
}
