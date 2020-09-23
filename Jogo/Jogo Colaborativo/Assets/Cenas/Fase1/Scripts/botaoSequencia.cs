using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoSequencia : MonoBehaviour
{
    public BotaoSequenciaSecundario segundoBotao;
    public BotaoSequenciaSecundario terceiroBotao;

    public GameObject portao;

    private bool pressed;
    private bool unlocked;
    void Start()
    {
        pressed = false;
        unlocked = false;
    }

    void Update()
    {
        if (unlocked)
            return;

        if (pressed)
        {
            if (segundoBotao.pressed)
            {
                if (terceiroBotao.pressed)
                {
                    unlock();
                }
            }else if (terceiroBotao.pressed)
            {
                resetSequencia();
            }
        }else if(segundoBotao.pressed || terceiroBotao.pressed)
        {
            resetSequencia();
        }
    }

    private void resetSequencia()
    {
        pressed = false;
        segundoBotao.pressed = false;
        terceiroBotao.pressed = false;
    }

    private void unlock()
    {
        Destroy(portao);
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        if (colidor.gameObject.tag == "Player1" || colidor.gameObject.tag == "Player2")
        {
            pressed = true;
        }
    }

}
