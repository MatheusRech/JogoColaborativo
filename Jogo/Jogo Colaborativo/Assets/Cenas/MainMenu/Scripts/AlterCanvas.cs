using System;
using UnityEngine;

//Script de controle dos menus

public class AlterCanvas : MonoBehaviour
{
    //Jogadores
    public GameObject Player1;
    public GameObject Player2;
    //Canvas do menu
    private GameObject canvasMenu;
    //Canavs da tela de config
    private GameObject canvasConfig;
    //Canvas que esta aberto
    private int canvasAtivo;

    //Recebe os canvas
    void Start()
    {
        try
        {
            canvasAtivo = 0;

            canvasMenu = GameObject.Find("MenuCanvas");
            canvasConfig = GameObject.Find("ConfigCanvas");

            //canvasConfig.SetActive(false); - Etva dando erro pq aqui executava primeiro que o outro script
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void closeCanvasConfig()
    {
        canvasConfig.SetActive(false);
    }
    //seleciona o menu ativo
    public void alterCanvas(int canvas)
    {
        
        if (canvasAtivo == canvas)
        {
            return;
        }

        switch (canvas)
        {
            case 0:
                canvasMenu.SetActive(true);
                canvasConfig.SetActive(false);
                canvasAtivo = 0;
                Player1.SetActive(true);
                Player2.SetActive(true);
                break;
            case 1:
                canvasMenu.SetActive(false);
                canvasConfig.SetActive(true);
                canvasAtivo = 1;
                Player1.SetActive(false);
                Player2.SetActive(false);
                break;
        }
    }
}
