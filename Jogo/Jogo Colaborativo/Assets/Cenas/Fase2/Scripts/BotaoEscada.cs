using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoEscada : MonoBehaviour
{
    public bool modo;
    public GameObject elevador;
    public float alturaMinima;
    public float alturaMaxima;
    
    public void pressed()
    {
        if(modo){
            elevador.transform.position = elevador.transform.position + new Vector3(0,1.5f,0);

            if(elevador.transform.position.y > alturaMaxima){
                Debug.Log("1");
                Debug.Log(new Vector3(elevador.transform.position.x, alturaMaxima, elevador.transform.position.z));
                elevador.transform.position = new Vector3(elevador.transform.position.x, alturaMaxima, elevador.transform.position.z);
                Debug.Log(elevador.transform.position);
            }
        }
        else
        {
            elevador.transform.position = elevador.transform.position - new Vector3(0,1.5f,0);

            if(elevador.transform.position.y < alturaMaxima){
                Debug.Log("2");
                Debug.Log(new Vector3(elevador.transform.position.x, alturaMinima, elevador.transform.position.z));
                elevador.transform.position = new Vector3(elevador.transform.position.x, alturaMinima, elevador.transform.position.z);
                Debug.Log(elevador.transform.position);
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
