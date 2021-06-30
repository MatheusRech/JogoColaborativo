using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragao : MonoBehaviour
{
    public GameObject fogoDragao;

    private Animator animation;

    private GameObject player1;
    private GameObject player2;

    private int ataques;
    private float player;
    private bool find;
    private bool atacou;
    private bool subir;

    void Start()
    {
        ataques = 0;
        animation = gameObject.GetComponent<Animator>();
        animation.SetBool("Ataque", false);
        find = false;
        atacou = false;
    }
    void Update()
    {
        if (!find)
        {
            try
            {
                player1 = GameObject.FindGameObjectWithTag("Player1");
                player2 = GameObject.FindGameObjectWithTag("Player2");
                find = true;
            }
            catch (Exception)
            {
                return;
            }
        }


        if (atacou)
        {
            if (ataques == 5)
            {
                ataques = 0;
                player = UnityEngine.Random.Range(0, 1);
            }

            if (player <= 0.4)
            {
                MoveDragao(player1);
            }
            else
            {
                MoveDragao(player2);
            }
        }
        else
        {
            if (player <= 0.4)
            {
                MoveDragao(player1);
            }
            else
            {
                MoveDragao(player2);
            }
        }

        
    }

    private void MoveDragao(GameObject player)
    {

        if (transform.position.y >= player.transform.position.y-1.8f && transform.position.y <= player.transform.position.y+1.8f)
        {
            StartAtaque();
            atacou = true;
        }
        else
        {
            if (transform.position.y > player.transform.position.y)
            {
                subir = false;
            }
            else
            {
                subir = true;
            }
            EndAtaque();
        }
    }

    private void StartAtaque()
    {
        animation.SetBool("Ataque", true);
    }

    public void Ataque()
    {
        GameObject ataque = Instantiate(fogoDragao);
        ataque.transform.position = transform.position - new Vector3(2, 0);
        ataques++;
        EndAtaque();
    }

    public void MovimentoSubindo()
    {
        if (!subir)
            return;
        for(int x = 0; x < 5; x++)
        {
            transform.position += new Vector3(0, 0.4f);
        }
    }

    public void MovimentoDescendo()
    {
        if (subir)
            return;

        for (int x = 0; x < 5; x++)
        {
            transform.position -= new Vector3(0, 0.3f);
        }
        
    }

    public void EndAtaque()
    {
        animation.SetBool("Ataque", false);
    }
}
