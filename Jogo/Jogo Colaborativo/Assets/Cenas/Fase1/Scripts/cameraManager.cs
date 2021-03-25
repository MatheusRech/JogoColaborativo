/*
 * 
 * Classe que configura a camera
 * 
 */

using System;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    //Objeto da camera
    public GameObject gameObjectCamera;
    //Classe da camera
    private Camera objetoCamera;
    //Posição dos jogadores
    private Vector3 player1;
    private Vector3 player2;
    //Posição da camera
    private Vector3 cameraPosition;
    //Disabilita o script temporariamente
    private bool disable;

    //Incia variaveis
    void Start()
    {
        objetoCamera = gameObjectCamera.GetComponent<Camera>();
        cameraPosition = gameObjectCamera.transform.position;
        disable = false;
    }

    //loop que fica reposicionando a camera
    void Update()
    {
        if (disable)
        {
            return;
        }

        //Caso um jogador seja deletado para o script pq deu muita merda
        try
        {
            player1 = GameObject.FindGameObjectWithTag("Player1").transform.position;
            player2 = GameObject.FindGameObjectWithTag("Player2").transform.position;
        }
        catch (Exception)
        {
            return;
        }

        //Posição media entre os jogadores no eixo x
        //  Distancia da camera
        float sizex = player1.x - player2.x;

        //Posição media entre os jogadores no eixo y
        float sizey = player1.y - player2.y;

        float size = sizex + sizey;

        //Correção de espaço caso seja negativo arruma as posições
        if (size < 0)
            size = (sizex * -1) + (sizey * -1);

        //Aplica a area de ampliação da camera
        objetoCamera.orthographicSize = size;
        //Aplica o maximo e o minimo de zoom
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

    //Função que desabilita/habilita o script
    public void disabilitarCamera(bool disable)
    {
        this.disable = disable;
    }
}
