using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoDeAltaPressao : MonoBehaviour
{

    public GameObject portao;

    private bool unlock;

    void Start()
    {
        unlock = false;
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        if (colidor.gameObject.tag == "Caixa" && !unlock)
        {

            Destroy(portao);

            unlock = true;
        }
    }
}
