﻿/*
 * 
 * Esse script ficou muito grande e algum dia pode ser alterado, mais eu fiz meio que na velociade
 * Controla as configurações do jogador e do jogo, esse script é um hub de todas as configs
 * 
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigControls : MonoBehaviour
{
    //jogador um
    public Player player1;
    //jogador dois
    public Player player2;
    //todos os itens configuraveis do jogador
    public List<GameObject> botoes;
    //menssagem de aviso sobre a configuraçao
    public Text warning;
    //imagens dos botoes do controle
    public Sprite[] imagensBotoes;
    //painel de configuração das cores
    public GameObject painelColor;

    //enumerado da tecla que está sendo alterada
    private enum teclaEscolha
    {
        Pular,
        Frente,
        Tras,
        Interacao
    }

    //configurãção do jogador um
    private Config config1;
    //configuração do jogador dois
    private Config config2;
    //variaveis de controle para saber qual tecla está sendo alterada
    private bool pular;
    private bool paraFrente;
    private bool paraTras;
    private bool interacao;
    //tecla precionada
    private Key keyPressed;

    void Start()
    {
        pular = false;
        paraFrente = false;
        paraTras = false;
        //carrega a configuração default
        config1 = Config.defaultConfig(1);
        config2 = Config.defaultConfig(2);

        warning.text = "";

    }

    void Update()
    {
        //Vai ser removido daqui
        try
        {
            switch (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value)
            {
                case 0:
                    config1.setVolumePrincipal(0);
                    config1.setVolumeMusica(0);
                    config1.setVolumeEfx(0);
                    break;
                case 1:
                    config2.setVolumePrincipal(0);
                    config2.setVolumeMusica(0);
                    config2.setVolumeEfx(0);
                    break;
            }
        }
        catch(Exception)
        {

        }
        //Quando um botao é clicado para altera a sua tecla, ex: cliquei no botão andar para frente
        if(pular || paraFrente || paraTras || interacao)
        {
            //Cria uma tecla vazia
            keyPressed = new Key();
            //Varre todas as teclas num loop para saber qual tecla foi precionada
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                //Se uma tecla esta precionada retorna true
                if (Input.GetKey(vKey))
                {
                    //se a tecla for diferente da tecla escape
                    if(vKey != KeyCode.Escape)
                    {
                        //verifica se a tecla ja não está em uma outra configuração
                        if(vKey == config1.paraFrente.keyCode || vKey == config1.paraTras.keyCode || vKey == config1.pular.keyCode || vKey == config2.paraFrente.keyCode || vKey == config2.paraTras.keyCode || vKey == config2.pular.keyCode)
                        {
                            pular = false;
                            paraFrente = false;
                            paraTras = false;
                            warning.text = "A tecla selecionada já está atribuida a alguma função.";
                        }
                        else
                        {
                            keyPressed = new Key(vKey);
                            warning.text = "Tecla selecionada pressione o botão de salvar para gravar a configuração.";
                        }  
                        
                    }
                    else
                    {
                        //tecla de cancelar a nova tecla foi clicada
                        pular = false;
                        paraFrente = false;
                        paraTras = false;
                        warning.text = "Ação cancelada.";
                    }
                }
            }
            //Coloca a tecla escolhida no lugar certo
            if (pular && keyPressed.keySeted)
            {
                changeTecla("Pular", teclaEscolha.Pular);
                pular = false;
            }
            else if (paraFrente && keyPressed.keySeted)
            {
                changeTecla("AndarParaFrente", teclaEscolha.Frente);
                paraFrente = false;
            }
            else if (paraTras && keyPressed.keySeted)
            {
                changeTecla("AndarParaTras", teclaEscolha.Tras);
                paraTras = false;
            }
            else if(interacao && keyPressed.keySeted)
            {
                changeTecla("InteraçãoObjetos", teclaEscolha.Interacao);
                interacao = false;
            }
        }
    }

    //Troca a tecla na config
    private void changeTecla(string nomeBotao, teclaEscolha opcao)
    {
        switch (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value)
        {
            case 0:
                if (opcao == teclaEscolha.Pular)
                {
                    config1.setKeyPular(keyPressed);
                }
                else if (opcao == teclaEscolha.Frente)
                {
                    config1.setKeyFrente(keyPressed);
                }
                else if (opcao == teclaEscolha.Tras)
                {
                    config1.setKeyTras(keyPressed);
                }
                else if(opcao == teclaEscolha.Interacao)
                {
                    config1.setKeyInteracao(keyPressed);
                }

                //Se for um joystick coloca a foto do botão
                foreach (GameObject botao in botoes)
                {
                    if (botao.name == nomeBotao)
                    {
                        Sprite imagemBotao = null;

                        if (keyPressed.keyCode.ToString().Contains("Joystick"))
                        {
                            string name = keyPressed.keyCode.ToString();

                            foreach(string a in Input.GetJoystickNames())
                            {
                                Debug.Log(a);
                            }

                            if (Input.GetJoystickNames()[int.Parse(name[8].ToString()) - 1] == "Controller (Xbox One For Windows)")
                            {
                                Debug.Log("XBOX");
                                switch (name.Substring(name.Length - 1))
                                {
                                    case "0":
                                        imagemBotao = imagensBotoes[0];
                                        break;
                                    case "1":
                                        imagemBotao = imagensBotoes[1];
                                        break;
                                    case "2":
                                        imagemBotao = imagensBotoes[2];
                                        break;
                                    case "3":
                                        imagemBotao = imagensBotoes[3];
                                        break;
                                }
                            }
                        }
                        if (imagemBotao != null)
                        {
                            botao.transform.Find("Imagem").GetComponent<Image>().color = new Color(255, 255, 255, 255);
                            botao.transform.Find("Imagem").GetComponent<Image>().sprite = imagemBotao;
                            botao.transform.Find("Valor").GetComponent<Text>().text = "";
                        }
                        else
                        {
                            botao.transform.Find("Imagem").GetComponent<Image>().color = new Color(255, 255, 255, 0);
                            botao.transform.Find("Valor").GetComponent<Text>().text = keyPressed.keyCode.ToString();
                        }

                    }
                }
                break;
            case 1:

                if (opcao == teclaEscolha.Pular)
                {
                    config2.setKeyPular(keyPressed);
                }
                else if (opcao == teclaEscolha.Frente)
                {
                    config2.setKeyFrente(keyPressed);
                }
                else if (opcao == teclaEscolha.Tras)
                {
                    config2.setKeyTras(keyPressed);
                }
                else if (opcao == teclaEscolha.Interacao)
                {
                    config2.setKeyInteracao(keyPressed);
                }

                foreach (GameObject botao in botoes)
                {
                    if (botao.name == nomeBotao)
                    {
                        Sprite imagemBotao = null;

                        if (keyPressed.keyCode.ToString().Contains("Joystick"))
                        {
                            string name = keyPressed.keyCode.ToString();

                            if (Input.GetJoystickNames()[int.Parse(name.Substring(8)) + 1] == "Controller (Xbox One For Windows)")
                            {
                                Debug.Log("XBOX");
                                switch (name.Substring(name.Length - 1))
                                {
                                    case "1":
                                        imagemBotao = imagensBotoes[0];
                                        break;
                                    case "2":
                                        imagemBotao = imagensBotoes[1];
                                        break;
                                    case "3":
                                        imagemBotao = imagensBotoes[2];
                                        break;
                                    case "4":
                                        imagemBotao = imagensBotoes[3];
                                        break;
                                }
                            }
                        }
                        if (imagemBotao != null)
                        {
                            botao.transform.Find("Imagem").GetComponent<Image>().color = new Color(255, 255, 255, 255);
                            botao.transform.Find("Imagem").GetComponent<Image>().sprite = imagemBotao;
                            botao.transform.Find("Valor").GetComponent<Text>().text = "";
                        }
                        else
                        {
                            botao.transform.Find("Imagem").GetComponent<Image>().color = new Color(255, 255, 255, 0);
                            botao.transform.Find("Valor").GetComponent<Text>().text = keyPressed.keyCode.ToString();
                        }


                    }
                }
                break;
        }
    }

    public void configAndarParaFrente()
    {
        paraFrente = true;
        warning.text = "Pressione algum botão que fará o personagem andar para frente ou a tecla ESC para cancelar.";
    }
    public void configAndarParaTras()
    {
        paraTras = true;
        warning.text = "Pressione algum botão que fará o personagem andar para tras ou a tecla ESC para cancelar.";
    }
    public void configPular()
    {
        pular = true;
        warning.text = "Pressione algum botão que fará o personagem pular ou a tecla ESC para cancelar.";
    }

    public void configInteracao()
    {
        interacao = true;
        warning.text = "Pressione algum botão que fará o personagem interagir com objetos ou a tecla ESC para cancelar.";
    }

    //Carrega a configuração do jogador selecionado
    public void setPlayer()
    {
        switch (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value)
        {
            case 0:
                foreach (GameObject objeto in botoes)
                {
                    switch (objeto.name)
                    {
                        case "VolumePrincipal":
                            objeto.GetComponent<Scrollbar>().value = config1.volumePrincipal;
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config1.volumePrincipal.ToString();
                            break;
                        case "VolumeMusica":
                            objeto.GetComponent<Scrollbar>().value = config1.volumeMusica;
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config1.volumeMusica.ToString();
                            break;
                        case "VolumeEfeitosEspecias":
                            objeto.GetComponent<Scrollbar>().value = config1.volumeEfx;
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config1.volumeEfx.ToString();
                            break;
                        case "Pular":
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config1.pular.keyCode.ToString();
                            break;
                        case "AndarParaTras":
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config1.paraTras.keyCode.ToString();
                            break;
                        case "AndarParaFrente":
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config1.paraFrente.keyCode.ToString();
                            break;
                        case "InteraçãoObjetos":
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config1.interacao.keyCode.ToString();
                            break;
                        case "ModoJoystick":
                            objeto.GetComponent<Toggle>().SetIsOnWithoutNotify(config1.modoJoystick);
                            break;
                    }
                }
                break;
            case 1:
                foreach (GameObject objeto in botoes)
                {
                    switch (objeto.name)
                    {
                        case "VolumePrincipal":
                            objeto.GetComponent<Scrollbar>().value = config2.volumePrincipal;
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config2.volumePrincipal.ToString();
                            break;
                        case "VolumeMusica":
                            objeto.GetComponent<Scrollbar>().value = config2.volumeMusica;
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config2.volumeMusica.ToString();
                            break;
                        case "VolumeEfeitosEspecias":
                            objeto.GetComponent<Scrollbar>().value = config2.volumeEfx;
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config2.volumeEfx.ToString();
                            break;
                        case "Pular":
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config2.pular.keyCode.ToString();
                            break;
                        case "AndarParaTras":
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config2.paraTras.keyCode.ToString();
                            break;
                        case "AndarParaFrente":
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config2.paraFrente.keyCode.ToString();
                            break;
                        case "InteraçãoObjetos":
                            objeto.transform.Find("Valor").GetComponent<Text>().text = config2.interacao.keyCode.ToString();
                            break;
                        case "ModoJoystick":
                            objeto.GetComponent<Toggle>().SetIsOnWithoutNotify(config2.modoJoystick);
                            break;
                    }
                }
                break;
        }
    }
    //Salva a config do jogador e do jogo
    public void salvar()
    {
        switch (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value)
        {
            case 0:
                player1.setConfig(config1);
                player1.saveConfig();
                break;
            case 1:
                player2.setConfig(config2);
                player2.saveConfig();
                break;
        }

        bool close = false;

        if(!painelColor.active){
            close = true;
        }

        painelColor.SetActive(true);

        try{
            if(GameObject.Find("UseColor").GetComponent<Toggle>().isOn){
                Color personagem = new Color(0,0,0);
                Color background = new Color(0,0,0);
                Color plataforma = new Color(0,0,0);
                Color interacao = new Color(0,0,0);

                string valorRed, valorGreen, valorBlue;
                
                var coresDisponiveis = new List<string> {"Personagem", "Background", "Plataforma", "Interacao"};

                foreach (string item in coresDisponiveis)
                {
                    valorRed = Math.Round((GameObject.Find("CorVermelha" + item).GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();
                    valorGreen = Math.Round((GameObject.Find("CorVerde" + item).GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();
                    valorBlue = Math.Round((GameObject.Find("CorAzul" + item).GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();

                    if(item == "Personagem"){
                        personagem = new Color((float.Parse(valorRed))/255, (float.Parse(valorGreen))/255, (float.Parse(valorBlue))/255);
                    }else if(item == "Background"){
                        background = new Color((float.Parse(valorRed))/255, (float.Parse(valorGreen))/255, (float.Parse(valorBlue))/255);
                    }else if(item == "Plataforma"){
                        plataforma = new Color((float.Parse(valorRed))/255, (float.Parse(valorGreen))/255, (float.Parse(valorBlue))/255);
                    }else{
                        interacao = new Color((float.Parse(valorRed))/255, (float.Parse(valorGreen))/255, (float.Parse(valorBlue))/255);
                    }
                }
                
                ColorConfig cores = new ColorConfig(personagem, background, plataforma, interacao);

                GameObject.Find("ConfigGame").GetComponent<ConfigGame>().setColorConfig(cores, true);
            }
        }catch(NullReferenceException erro){
            Debug.Log("Objeto useColor nao foi encontrado");
        }
        finally{
            if(close){
                painelColor.SetActive(false);
            }
        }
        
    }

    //Não está implementado
    public void onJoystickModeSet()
    {
        warning.text = "Após você alterar está configuração os controles do personagem só iram funcionar no Joystick.";
        if (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value == 0)
        {
            config1.setModeJoystick(GameObject.Find("ModoJoystick").GetComponent<Toggle>().isOn);
        }
        else
        { 
            config2.setModeJoystick(GameObject.Find("ModoJoystick").GetComponent<Toggle>().isOn);
        }
    }

    //Não está implementado
    public void onJoystickSelect()
    {
        if (GameObject.Find("JoystickSelection").GetComponent<Dropdown>().value == 0)
            return;


        warning.text = "Joystick selecionado.";
        if (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value == 0)
        {
            config1.setJoystick(GameObject.Find("JoystickSelection").GetComponent<Dropdown>().value);
        }
        else
        {
            config2.setJoystick(GameObject.Find("JoystickSelection").GetComponent<Dropdown>().value);
        }
    }
    //Carrega a config após a tela abrir
    public void carregarConfig()
    {
        player1.loadConfig();
        player2.loadConfig();

        config1 = player1.config;
        config2 = player2.config;

        setPlayer();

        GameObject joytisckSelection = GameObject.Find("JoystickSelection");

        foreach (string joystick in Input.GetJoystickNames())
        {
            joytisckSelection.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(joystick));
        }
    }
}
