using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudioValue : MonoBehaviour
{
    public GameObject audioMaster;
    public GameObject audioMusica;
    public GameObject audioVfx;
    void Start()
    {

    }

    void Update()
    {
        audioMaster.transform.Find("Valor").GetComponent<Text>().text = (audioMaster.GetComponent<Scrollbar>().value * 100).ToString("F");
        audioMusica.transform.Find("Valor").GetComponent<Text>().text = (audioMusica.GetComponent<Scrollbar>().value * 100).ToString("F");
        audioVfx.transform.Find("Valor").GetComponent<Text>().text = (audioVfx.GetComponent<Scrollbar>().value * 100).ToString("F");
    }
}
