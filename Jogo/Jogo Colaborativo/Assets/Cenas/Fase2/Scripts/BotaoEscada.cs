using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoEscada : MonoBehaviour
{
    public bool modo;
    public GameObject elevador;
    public double alturaMinima;
    public double alturaMaxima;

    void Start()
    {
        
    }

    public void pressed()
    {
        if (modo)
        {
            if (!(alturaMaxima >= (elevador.transform.position.y)+ 1.5))
            {
                elevador.transform.position = new Vector3(elevador.transform.position.x, elevador.transform.position.y + 1.5f, elevador.transform.position.z);
            }
            else
            {
                elevador.transform.position = new Vector3(elevador.transform.position.x, float.Parse(alturaMaxima.ToString()), elevador.transform.position.z);
            }
        }
        else
        {
            if (!(alturaMinima <= (elevador.transform.position.y - 1.5)))
            {
                elevador.transform.position = new Vector3(elevador.transform.position.x, elevador.transform.position.y - 1.5f, elevador.transform.position.z);
            }
            else
            {
                elevador.transform.position = new Vector3(elevador.transform.position.x, float.Parse(alturaMaxima.ToString()), elevador.transform.position.z);
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
                    pressed();
                    return;
                }

                //Em cima
            }

        }
    }
}
