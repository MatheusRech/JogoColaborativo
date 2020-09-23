using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoSequenciaSecundario : MonoBehaviour
{
    public bool pressed;

    void Start()
    {
        pressed = false;
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        if (colidor.gameObject.tag == "Player1" || colidor.gameObject.tag == "Player2")
        {
            pressed = true;
        }
    }
}
