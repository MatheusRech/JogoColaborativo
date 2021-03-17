using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RgbColorPicker : MonoBehaviour
{
    private GameObject red;
    private GameObject green;
    private GameObject blue;
    private Image preview;

    private string valorRed;
    private string valorGreen;
    private string valorBlue;

    void reload(string nomeObjeto)
    {
        red = GameObject.Find("CorVermelha" + nomeObjeto);
        green = GameObject.Find("CorVerde" + nomeObjeto);
        blue = GameObject.Find("CorAzul" + nomeObjeto);
        preview = GameObject.Find("PreviewColor" + nomeObjeto).GetComponent<Image>();

        valorRed = Math.Round((red.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();
        valorGreen = Math.Round((green.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();
        valorBlue = Math.Round((blue.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();
        alterPreviw();
    }

    public void setRed(string nomeObjeto)
    {
        reload(nomeObjeto);

        valorRed = Math.Round((red.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();

        red.transform.GetChild(2).gameObject.GetComponent<Text>().text = valorRed;

        alterPreviw();
    }
    public void setGreen(string nomeObjeto)
    {
        reload(nomeObjeto);

        valorGreen = Math.Round((green.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();

        green.transform.GetChild(2).gameObject.GetComponent<Text>().text = valorGreen;

        alterPreviw();
    }

    public void setBlue(string nomeObjeto)
    {
        reload(nomeObjeto);

        valorBlue = Math.Round((blue.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();

        blue.transform.GetChild(2).gameObject.GetComponent<Text>().text = valorBlue;

        alterPreviw();
    }

    private void alterPreviw()
    {
        preview.color = new Color((float.Parse(valorRed))/255, (float.Parse(valorGreen))/255, (float.Parse(valorBlue))/255);
    }
}
