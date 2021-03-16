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

    void Start()
    {
        red = GameObject.Find("CorVermelhaPersonagem");
        green = GameObject.Find("CorVerdePersonagem");
        blue = GameObject.Find("CorAzulPersonagem");
        preview = GameObject.Find("PreviewColorPersonagem").GetComponent<Image>();
        valorRed = "0";
        valorGreen = "0";
        valorBlue = "0";
        alterPreviw();
}

    public void setRed()
    {
        valorRed = Math.Round((red.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();

        red.transform.GetChild(2).gameObject.GetComponent<Text>().text = valorRed;

        alterPreviw();
    }
    public void setGreen()
    {
        valorGreen = Math.Round((green.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();

        green.transform.GetChild(2).gameObject.GetComponent<Text>().text = valorGreen;

        alterPreviw();
    }

    public void setBlue()
    {
        valorBlue = Math.Round((blue.GetComponent<Scrollbar>().value * 255), MidpointRounding.AwayFromZero).ToString();

        blue.transform.GetChild(2).gameObject.GetComponent<Text>().text = valorBlue;

        alterPreviw();
    }

    private void alterPreviw()
    {
        preview.color = new Color((float.Parse(valorRed))/255, (float.Parse(valorGreen))/255, (float.Parse(valorBlue))/255);
    }
}
