using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoPortao : MonoBehaviour
{
    public GameObject portao;
    public bool subir;

    private bool isPressed;

    private Vector3 positionPortaoPrimario;

    void Start()
    {
        isPressed = false;
        positionPortaoPrimario = portao.transform.position;
    }

    private void pressed()
    {
        if (isPressed)
            return;

        positionPortaoPrimario = portao.transform.position;

        if (!subir)
        {
            positionPortaoPrimario.y -= 5.8f;

        }
        else
        {
            positionPortaoPrimario.y += 5.8f;
        }

        portao.transform.position = positionPortaoPrimario;

        isPressed = true;
    }


    private void OnCollisionEnter2D(Collision2D colidor)
    {
        if(colidor.gameObject.tag == "Player1" || colidor.gameObject.tag == "Player2")
        {
            pressed();
        }
    }
}
