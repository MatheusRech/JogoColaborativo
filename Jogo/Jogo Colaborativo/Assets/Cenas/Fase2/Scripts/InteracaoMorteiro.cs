using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoMorteiro : MonoBehaviour, Interacao
{
    public void interagir()
    {
        gameObject.GetComponent<Morteiro>().disparar();
    }
}
