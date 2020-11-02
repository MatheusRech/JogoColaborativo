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
