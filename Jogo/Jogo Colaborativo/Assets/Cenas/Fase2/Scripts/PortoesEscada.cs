using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abre os portões quando o jogador um passa para o outro lado

public class PortoesEscada : MonoBehaviour
{
    public GameObject portaoUm;
    public GameObject portaoDois;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            portaoUm.transform.position = portaoUm.transform.position - new Vector3(0,8,0);
            portaoDois.transform.position = portaoDois.transform.position + new Vector3(0, 8.5f, 0);
        }
    }
}
