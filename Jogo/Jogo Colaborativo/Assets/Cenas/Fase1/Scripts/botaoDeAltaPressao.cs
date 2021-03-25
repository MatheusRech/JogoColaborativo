/*
 * 
 * Botão que é precisonado pela caixa
 * 
 */

using System.Collections.Generic;
using UnityEngine;

public class botaoDeAltaPressao : MonoBehaviour
{
    //Portão que libera com o precionamento
    public GameObject portao;
    //Controle para saber se o portão deve subir ou descer
    public bool subir;

    //Controle para saber se o portão ja foi movido
    private bool unlock;
    //Posição do portão
    private Vector3 positionPortaoPrimario;

    void Start()
    {
        unlock = false;
    }
    //função chamada quando o botão é precionado
    private void pressed()
    {
        //Se ja moveu não executa mais
        if (unlock)
            return;

        positionPortaoPrimario = portao.transform.position;

        if (!subir)
        {
            positionPortaoPrimario.y -= 5.8f;

        }
        else
        {
            positionPortaoPrimario.y += 5.8f;
        }
        
        //Move o portão
        portao.transform.position = positionPortaoPrimario;

        unlock = true;
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        List<ContactPoint2D> lista = new List<ContactPoint2D>();

        colidor.GetContacts(lista);

        foreach (ContactPoint2D hitPos in lista)
        {
            if (hitPos.normal.y < 0)

                //Colisão foi com a caixa move o portão
                if (colidor.gameObject.tag == "Caixa")
                {
                    pressed();
                }
        }
    }
}
