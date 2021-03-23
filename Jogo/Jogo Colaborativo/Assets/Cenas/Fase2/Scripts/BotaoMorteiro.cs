using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoMorteiro : MonoBehaviour
{
    public bool press { get; private set; }

    private void Start()
    {
        press = false;
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
