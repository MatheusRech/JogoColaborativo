using System.IO;
using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Config config;
    public int numberPlayer;
    public List<string> colisores = new List<string>();

    private GameObject BoxFala;

    private Rigidbody2D rigidbodyObject;
    private SpriteRenderer rendererObject;

    private bool frente;
    private bool tras;
    private bool ground;
    private Vector2 velocidade;
    private GameObject objetoInteracao;

    void Start()
    {
        BoxFala = gameObject.transform.GetChild(0).gameObject;
        BoxFala.SetActive(false);
        DontDestroyOnLoad(this);
        loadConfig();

        rigidbodyObject = gameObject.GetComponent<Rigidbody2D>();
        rendererObject = gameObject.GetComponent<SpriteRenderer>();

        velocidade = new Vector2(0, 0);

        ground = false;
    }

    void Update()
    {
        velocidade = new Vector2(0, 0);
        if (!config.modoJoystick)
        {
            if (Input.GetKeyDown(config.paraFrente.keyCode))
            {
                frente = true;
            }
            else if (Input.GetKeyUp(config.paraFrente.keyCode))
            {
                frente = false;
            }

            if (Input.GetKeyDown(config.paraTras.keyCode))
            {
                tras = true;
            }
            else if (Input.GetKeyUp(config.paraTras.keyCode))
            {
                tras = false;
            }

            if (frente)
            {
                velocidade.x = 3.7f;
                rendererObject.flipX = false;
            }
            else if (tras)
            {
                velocidade.x = -3.7f;
                rendererObject.flipX = true;
            }
        }
        else
        {
            velocidade.x = Input.GetAxis("Joy" + config.joystickSelection.ToString());
        }
        

        if(ground && Input.GetKeyDown(config.pular.keyCode))
        {
            velocidade.y = 400;
        }

        if (Input.GetKeyDown(config.interacao.keyCode))
        {
            if(objetoInteracao != null)
            {
                try
                {
                    Interacao interacao = (Interacao)objetoInteracao.GetComponent(typeof(Interacao));
                    interacao.interagir();
                }
                catch (Exception)
                {
                    Debug.Log("Objeto nao possui Interface interacao");
                }
            }
        }

        rigidbodyObject.AddForce(velocidade);
    }

    public void setConfig(Config config)
    {
        this.config = config;
    }

    public void loadConfig()
    {
        this.config = Config.loadConfig(numberPlayer);
    }

    public void saveConfig()
    {
        this.config.saveConfig(this.numberPlayer);
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        if (colisores.Contains(colidor.transform.gameObject.tag))
        {
            ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D colidor)
    {
        if (colisores.Contains(colidor.transform.gameObject.tag))
        {
            ground = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        objetoInteracao = colisor.transform.gameObject;

        try
        {
            BoxFala.SetActive(true);
            BoxFala.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = colisor.GetComponent<TutorialMensagem>().mensagem;
        }
        catch (System.Exception)
        {
            BoxFala.SetActive(false);
            Debug.Log("Erro na colisao com a trigger!");
        }
        
    }

    private void OnTriggerExit2D(Collider2D colisor)
    {
        objetoInteracao = null;
        BoxFala.SetActive(false);
    }
}
