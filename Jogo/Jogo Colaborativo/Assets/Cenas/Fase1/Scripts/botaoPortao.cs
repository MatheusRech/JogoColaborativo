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
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.39f, gameObject.transform.position.z);


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


    private void OnCollisionEnter2D(Collision2D colisor)
    {

        List<ContactPoint2D> lista = new List<ContactPoint2D>();

        colisor.GetContacts(lista);

        foreach (ContactPoint2D hitPos in lista)
        {
            if (hitPos.normal.y < 0)
            {
                if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
                {
                    pressed(); ;
                }

                //Em cima
            }

        }
    }
}
