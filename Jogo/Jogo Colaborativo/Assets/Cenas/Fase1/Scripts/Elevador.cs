using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script do elevador, bem simples detecta a clisão e começar a subir, caso nao detecta desce

public class Elevador : MonoBehaviour
{
    public Vector3 maximo;
    private Vector3 minimo;
    private bool elevar;
    void Start()
    {
        elevar = false;
        minimo = gameObject.transform.position;
    }

    void Update()
    {
        if (elevar && gameObject.transform.position.y < maximo.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.01f, gameObject.transform.position.z);
        }
        else if(elevar == false && gameObject.transform.position.y > minimo.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.01f, gameObject.transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            List<ContactPoint2D> lista = new List<ContactPoint2D>();

            colisor.GetContacts(lista);

            foreach (ContactPoint2D hitPos in lista)
            {
                if (hitPos.normal.y < 0)
                {
                    elevar = true;
                    //Em cima
                }
                else if (hitPos.normal.y > 0)
                {
                    //Em baixo
                }
                else
                {
                    //Meio
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {

            elevar = false;

        }
    }


}
