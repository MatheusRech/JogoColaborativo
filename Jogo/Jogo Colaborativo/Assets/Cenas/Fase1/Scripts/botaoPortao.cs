using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoPortao : MonoBehaviour
{
    public GameObject portaoPrimario;
    public GameObject portaoSecundario;
    public int numberButao;

    private bool state;
    private bool isPressed;

    private Vector3 positionPortaoPrimario;
    private Vector3 positionPortaoSecundario;

    void Start()
    {
        state = false;
        isPressed = false;
        positionPortaoPrimario = portaoPrimario.transform.position;
        positionPortaoSecundario = portaoSecundario.transform.position;
    }

    void Update()
    {
    }

    private void pressed()
    {

        if (isPressed)
            return;
        
        if (state)
        {
            positionPortaoPrimario.y -= 5.8f;
            positionPortaoSecundario.y += 5.8f;
        }
        else
        {
            positionPortaoPrimario.y += 5.8f;
            positionPortaoSecundario.y -= 5.8f;
        }

        portaoPrimario.transform.position = positionPortaoPrimario;
        portaoSecundario.transform.position = positionPortaoSecundario;

        state = !state;

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
