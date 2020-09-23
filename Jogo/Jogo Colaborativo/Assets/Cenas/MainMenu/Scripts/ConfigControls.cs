using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigControls : MonoBehaviour
{
    public Player player1;
    public Player player2;

    public List<GameObject> botoes;

    private Config config1;
    private Config config2;

    private bool pular;
    private bool paraFrente;
    private bool paraTras;

    private Key keyPressed;

    void Start()
    {
        pular = false;
        paraFrente = false;
        paraTras = false;

        config1 = new Config();
        config2 = new Config();
    }

    void Update()
    {
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

        if(pular || paraFrente || paraTras)
        {
            keyPressed = new Key();

            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    keyPressed = new Key(vKey);
                }
            }

            if (pular && keyPressed.keySeted)
            {
                switch (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value)
                {
                    case 0:
                        config1.setKeyPular(keyPressed);
                        foreach (GameObject botao in botoes)
                        {
                            if (botao.name == "Pular")
                            {
                                botao.transform.Find("Valor").GetComponent<Text>().text = config1.pular.keyCode.ToString();
                            }
                        }
                        break;
                    case 1:
                        config2.setKeyPular(keyPressed);
                        foreach (GameObject botao in botoes)
                        {
                            if (botao.name == "Pular")
                            {
                                botao.transform.Find("Valor").GetComponent<Text>().text = config2.pular.keyCode.ToString();
                            }
                        }
                        break;
                }
                pular = false;
            }
            else if (paraFrente && keyPressed.keySeted)
            {
                switch (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value)
                {
                    case 0:
                        config1.setKeyFrente(keyPressed);
                        foreach (GameObject botao in botoes)
                        {
                            if (botao.name == "AndarParaFrente")
                            {
                                botao.transform.Find("Valor").GetComponent<Text>().text = config1.paraFrente.keyCode.ToString();
                            }
                        }
                        break;
                    case 1:
                        config2.setKeyFrente(keyPressed);
                        foreach (GameObject botao in botoes)
                        {
                            if (botao.name == "AndarParaFrente")
                            {
                                botao.transform.Find("Valor").GetComponent<Text>().text = config2.paraFrente.keyCode.ToString();
                            }
                        }
                        break;
                }

                paraFrente = false;
            }
            else if (paraTras && keyPressed.keySeted)
            {
                switch (GameObject.Find("SeletorJogador").GetComponent<Dropdown>().value)
                {
                    case 0:
                        config1.setKeyTras(keyPressed);
                        foreach (GameObject botao in botoes)
                        {
                            if (botao.name == "AndarParaTras")
                            {
                                botao.transform.Find("Valor").GetComponent<Text>().text = config1.paraTras.keyCode.ToString();
                            }
                        }
                        break;
                    case 1:
                        config2.setKeyTras(keyPressed);
                        foreach (GameObject botao in botoes)
                        {
                            if (botao.name == "AndarParaTras")
                            {
                                botao.transform.Find("Valor").GetComponent<Text>().text = config1.paraTras.keyCode.ToString();
                            }
                        }
                        break;
                }

                paraTras = false;
            }
        }
    }

    public void configAndarParaFrente()
    {
        paraFrente = true;
    }
    public void configAndarParaTras()
    {
        paraTras = true;
    }
    public void configPular()
    {
        pular = true;
    }


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
                    }
                }
                break;
        }
    }

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
    }

    public void carregarConfig()
    {
        player1.loadConfig();
        player2.loadConfig();

        config1 = player1.config;
        config2 = player2.config;

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
            }
        }
    }
}
