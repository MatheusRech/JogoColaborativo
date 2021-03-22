using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoEscada : MonoBehaviour
{
    public bool modo;
    public GameObject elevador;
    public float alturaMinima;
    public float alturaMaxima;

    private bool press = false;
    
    void Update()
    {
        if (press)
        {
            pressed();
        }
    }

    public void pressed()
    {
        if(modo){
            if (elevador.transform.position.y < alturaMinima){
                elevador.transform.position = elevador.transform.position + new Vector3(0, 0.02f, 0);
            }
        }
        else
        {
            if(elevador.transform.position.y > alturaMaxima){
                elevador.transform.position = elevador.transform.position - new Vector3(0, 0.02f, 0);
            }
        }
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
                    press = true;
                    return;
                }

                //Em cima
            }

        }
    }

    private void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            press = false;
            return;
        }
    }

}
