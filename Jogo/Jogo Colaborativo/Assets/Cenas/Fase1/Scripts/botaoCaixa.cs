using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoCaixa : MonoBehaviour
{
    public GameObject Caixa;
    public Vector3 spwan;

    private List<GameObject> caixas;
    private bool pressed;

    void Start()
    {
        caixas = new List<GameObject>();
        pressed = false;
    }

    void Update()
    {
        
    }

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
