/*
 * 
 * Classe do botão de sequencia
 * 
 */

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
        if (pressed == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.39f, gameObject.transform.position.z);
        }
        if (segundoBotao.pressed == true)
        {
            segundoBotao.gameObject.transform.position = new Vector3(segundoBotao.gameObject.transform.position.x, segundoBotao.gameObject.transform.position.y + 0.39f, segundoBotao.gameObject.transform.position.z);
        }
        if (terceiroBotao.pressed == true)
        {
            terceiroBotao.gameObject.transform.position = new Vector3(terceiroBotao.gameObject.transform.position.x, terceiroBotao.gameObject.transform.position.y + 0.39f, terceiroBotao.gameObject.transform.position.z);
        }
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

        List<ContactPoint2D> lista = new List<ContactPoint2D>();

        colidor.GetContacts(lista);

        foreach (ContactPoint2D hitPos in lista)
        {
            if (hitPos.normal.y < 0)
            {
                if (colidor.gameObject.tag == "Player1" || colidor.gameObject.tag == "Player2" && !pressed)
                {
                    pressed = true;
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.39f, gameObject.transform.position.z);
                }

                //Em cima
            }

        }
    }

}
