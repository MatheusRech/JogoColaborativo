using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que comanda os elevadores da escada

public class BotaoEscada : MonoBehaviour
{
    //Modo: sobe ou desce
    public bool modo;
    //Elevador que vai ser atuado
    public GameObject elevador;
    //altura minima do elevador
    public float alturaMinima;
    //altura maxima
    public float alturaMaxima;
    //se o botão está precionado
    private bool press = false;
    
    void Update()
    {
        //chama o atuador
        if (press)
        {
            pressed();
        }
    }

    public void pressed()
    {
        if(modo){
            //Move o elevador para cima
            if (elevador.transform.position.y < alturaMinima){
                elevador.transform.position = elevador.transform.position + new Vector3(0, 0.02f, 0);
            }
        }
        else
        {
            //Move o elevador para baixo
            if (elevador.transform.position.y > alturaMaxima){
                elevador.transform.position = elevador.transform.position - new Vector3(0, 0.02f, 0);
            }
        }
    }
    //Detecta a colisão com o jogador
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
                    press = true;
                    return;
                }

                //Em cima
            }

        }
    }

    //Detecta a saida do objeto
    private void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            press = false;
            return;
        }
    }

}
