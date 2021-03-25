/*
 * 
 * Classe para criar a caixa que o jagador precisa para desbloquear os portões
 * 
 */

using System.Collections.Generic;
using UnityEngine;

public class botaoCaixa : MonoBehaviour
{
    //Prefab da caixa
    public GameObject Caixa;
    //Local de spaw da caixa
    public Vector3 spwan;

    //caixas criadas
    private List<GameObject> caixas;
    //estado do botão
    private bool pressed;

    void Start()
    {
        caixas = new List<GameObject>();
        pressed = false;
    }

    //Cria a caixa na posição
    private void OnCollisionEnter2D(Collision2D colidor)
    {

        List<ContactPoint2D> lista = new List<ContactPoint2D>();

        colidor.GetContacts(lista);

        foreach (ContactPoint2D hitPos in lista)
        {
            if (hitPos.normal.y < 0)
            {
                if (colidor.gameObject.tag == "Player1" || colidor.gameObject.tag == "Player2")
                {
                    if (pressed)
                        return;
                    pressed = true;
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.39f, gameObject.transform.position.z);
                    
                    //Caso já exita uma caixa destroy a ultima e cria uma nova
                    if (caixas.Count > 0)
                    {
                        Destroy(caixas[0]);
                        caixas.RemoveAt(0);
                    }

                    GameObject prefab = Instantiate(Caixa);
                    prefab.transform.position = spwan;

                    caixas.Add(prefab);

                    
                }

                //Em cima
            }

        }

        
    }
}
