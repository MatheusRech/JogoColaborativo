/*
 * 
 * Classe utilizada para gerenciar as atividades do jogador
 * 
 */



using System.IO;
using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    //Config armazena todas configurações do jogar
    public Config config;
    //Numero do jogador
    public int numberPlayer;
    //Lista das tag dos objetos em que o jogador pode pular
    public List<string> colisores = new List<string>();
    //Caixa de dialogo de instução do jogador
    private GameObject BoxFala;

    //Elemento de fisica
    private Rigidbody2D rigidbodyObject;
    //Elemento de rederisão do player
    private SpriteRenderer rendererObject;

    //Variaveis de controle para os movimentos
    private bool frente;
    private bool tras;
    //Variavel de controle de pulo
    private bool ground;
    //Velocidade de movimenro
    private Vector2 velocidade;
    //Variavel que armazena o ultimo objeto interagivel colidido.
    private GameObject objetoInteracao;

    void Start()
    {
        //Carrega as variaveis iniciais
        BoxFala = gameObject.transform.GetChild(0).gameObject;
        BoxFala.SetActive(false);
        DontDestroyOnLoad(this);
        //Carrega config do jogador
        loadConfig();

        rigidbodyObject = gameObject.GetComponent<Rigidbody2D>();
        rendererObject = gameObject.GetComponent<SpriteRenderer>();

        velocidade = new Vector2(0, 0);

        ground = false;
    }

    void Update()
    {
        velocidade = new Vector2(0, 0);
        //Modo joystick está disativado(abilita o movimento pelo joystick)
        if (!config.modoJoystick)
        {
            //Recebe as teclas precionadas

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

            //Aplica movimento recebido do teclado para a variavel de controle de velocidade

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
            //Aplica o movimento ao player por meio de um jostick
            velocidade.x = Input.GetAxis("Joy" + config.joystickSelection.ToString());
        }
        
        //Controle de pulo
        if(ground && Input.GetKeyDown(config.pular.keyCode))
        {
            velocidade.y = 400;
        }

        //Botão de interagir
        if (Input.GetKeyDown(config.interacao.keyCode))
        {
            //Caso o jogador está na aerea de um objeto interagivel
            if(objetoInteracao != null)
            {  
                try
                {
                    //tenta capturar todos os componentes do objeto interagivel que implementam a interface Interacao
                    var interfaceScripts = objetoInteracao.GetComponents<MonoBehaviour>().OfType<Interacao>();

                    //Executa as implementações
                    foreach (var iScript in interfaceScripts)
                    {
                        iScript.interagir();
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Objeto nao possui Interface interacao: " + objetoInteracao.name + "\n" + e.Message);
                }
            }
        }

        //Aplica movimento ao jogador
        rigidbodyObject.AddForce(velocidade);
    }

    //Salva a nova config no jogador
    public void setConfig(Config config)
    {
        this.config = config;
    }

    //Carrega config do jogador
    public void loadConfig()
    {
        this.config = Config.loadConfig(numberPlayer);
    }
    
    //Salva a nova config no dispositivo
    public void saveConfig()
    {
        this.config.saveConfig(this.numberPlayer);
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        //Ao colidir verifica se pode ser habilitado o jogador pular
        if (colisores.Contains(colidor.transform.gameObject.tag))
        {
            ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D colidor)
    {
        //Ao colidir verifica se pode ser habilitado o jogador pular
        if (colisores.Contains(colidor.transform.gameObject.tag))
        {
            ground = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        //Colidiu com uma trigger

        //Salva o colisor para executar as interaçõs com objetos que implementam a interação
        objetoInteracao = colisor.transform.gameObject;

        try
        {
            //Tenta abrir a menssagem de ajuda
            BoxFala.SetActive(true);
            BoxFala.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = colisor.GetComponent<TutorialMensagem>().mensagem;
        }
        catch (System.Exception e)
        {
            //Caso não existe menssagem de ajuda na trigger fecha o box de ajuda
            BoxFala.SetActive(false);
            Debug.Log("Erro na colisao com a trigger!\n"+e.Message);
        }
        
    }

    private void OnTriggerExit2D(Collider2D colisor)
    {
        //Saiu da trigger, remove o objeto que possia a trigger e fecha o box de ajuda
        objetoInteracao = null;
        BoxFala.SetActive(false);
    }
}
