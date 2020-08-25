using System;
using UnityEngine;

public class AlterPanelConfig : MonoBehaviour
{
    private GameObject configAudio;
    private GameObject configControle;

    private int panelAtivo;
    void Start()
    {
        try
        {
            panelAtivo = 0;

            configAudio = GameObject.Find("AudioPanel");
            configControle = GameObject.Find("ControlePanel");
            configControle.SetActive(false);
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

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
                panelAtivo = 0;
                break;
            case 1:
                configAudio.SetActive(false);
                configControle.SetActive(true);
                panelAtivo = 1;
                break;
        }
    }

}
