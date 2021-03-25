using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe que implementa a interacao do morteiro
public class InteracaoMorteiro : MonoBehaviour, Interacao
{
    public void interagir()
    {
        gameObject.GetComponent<Morteiro>().disparar();
    }
}
