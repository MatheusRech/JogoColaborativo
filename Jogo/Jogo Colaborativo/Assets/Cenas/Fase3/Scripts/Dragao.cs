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

    void Start()
    {
        animation = gameObject.GetComponent<Animator>();
        animation.SetBool("Ataque", false);
        find = false;
    }
    void Update()
    {
        if (!find)
        {
            try
            {
                player1 = GameObject.FindGameObjectWithTag("Jogador1");
                player2 = GameObject.FindGameObjectWithTag("Jogador2");
                find = true;
            }
            catch (Exception)
            {
                return;
            }
        }
        

        if (ataques == 5)
        {
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

    private void MoveDragao(GameObject player)
    {
        if (transform.position.y == player.transform.position.y)
        {
            StartAtaque();
        }
        else
        {
            if (transform.position.y > player.transform.position.y)
            {
                transform.position -= new Vector3(0, 0.4f);
            }
            else
            {
                transform.position += new Vector3(0, 0.4f);
            }
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
    }

    public void EndAtaque()
    {
        animation.SetBool("Ataque", false);
    }
}
