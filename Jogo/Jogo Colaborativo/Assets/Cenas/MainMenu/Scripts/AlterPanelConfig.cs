using System;
using UnityEngine;

//Controle dos paines de configuração

public class AlterPanelConfig : MonoBehaviour
{
    private GameObject configAudio;
    private GameObject configControle;
    private GameObject configCor;

    private int panelAtivo;
    void Start()
    {
        try
        {
            panelAtivo = 0;

            configAudio = GameObject.Find("AudioPanel");
            configControle = GameObject.Find("ControlePanel");
            configCor = GameObject.Find("ColorPanel");
            configCor.SetActive(false);
            configControle.SetActive(false);
            gameObject.GetComponent<AlterCanvas>().closeCanvasConfig();
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    //seleciona o painel aberto
    public void alterPanel(int panel)
    {
        if(panel == panelAtivo)
        {
            return;
        }

        switch (panel)
        {
            case 0:
                configAudio.SetActive(true);
                configControle.SetActive(false);
                configCor.SetActive(false);
                panelAtivo = 0;
                break;
            case 1:
                configAudio.SetActive(false);
                configControle.SetActive(true);
                configCor.SetActive(false);
                gameObject.GetComponent<ConfigControls>().carregarConfig();
                panelAtivo = 1;
                break;
            case 2:
                configAudio.SetActive(false);
                configControle.SetActive(false);
                configCor.SetActive(true);
                panelAtivo = 2;
                break;
        }
    }

}
