using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoCaixa : MonoBehaviour
{
    public GameObject Caixa;
    public Vector3 spwan;

    private List<GameObject> caixas;

    void Start()
    {
        caixas = new List<GameObject>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        if (colidor.gameObject.tag == "Player1" || colidor.gameObject.tag == "Player2")
        {
            if(caixas.Count > 0)
            {
                Destroy(caixas[0]);
                caixas.RemoveAt(0);
            }

            GameObject prefab = Instantiate(Caixa);
            prefab.transform.position = spwan;

            caixas.Add(prefab);
        }
    }
}
