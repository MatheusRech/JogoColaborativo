using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoDeAltaPressao : MonoBehaviour
{

    public GameObject portao;
    public bool subir;

    private bool unlock;
    private Vector3 positionPortaoPrimario;

    void Start()
    {
        unlock = false;
    }

    private void pressed()
    {
        if (unlock)
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

        unlock = true;
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        if (colidor.gameObject.tag == "Caixa")
        {

            pressed();
        }
    }
}
