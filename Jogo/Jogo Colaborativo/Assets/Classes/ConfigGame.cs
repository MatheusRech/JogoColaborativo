using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigGame : MonoBehaviour
{
    private ColorConfig configColor;
    private bool useColor;

    void Start(){
        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += loadConfigGame;
    }

    private void loadConfigGame(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != "MainMenu")
        {
            attColors();
        }
        
    }

    public void setColorConfig(ColorConfig newColor, bool useColor)
    {
        this.useColor = useColor;
        this.configColor = newColor;
    }

    private void attColors()
    {

        if(useColor){
            GameObject.FindWithTag("Player1").GetComponent<SpriteRenderer>().material.SetColor("_Color", configColor.getPersonagem());
            GameObject.FindWithTag("Player2").GetComponent<SpriteRenderer>().material.SetColor("_Color", configColor.getPersonagem());

            Color corPlataforma = configColor.getPlataforma();

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Plataforma"))
            {
                item.GetComponent<SpriteRenderer>().material.SetColor("_Color", corPlataforma);
            }

            GameObject.Find("BG").GetComponent<Image>().color = configColor.getBackground();
        }

        
    }

}
