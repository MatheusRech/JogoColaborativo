/*
 * 
 * Classe que implemnta as configurações do jogador sobre o game
 * 
 * Ex: cores do jogo, son
 * 
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigGame : MonoBehaviour
{
    //Classe que armazena a configuração de cor
    private ColorConfig configColor;
    //Config de cor deve ser usada ?
    private bool useColor;

    void Start(){

        // Manter o objeto em todas as fases
        DontDestroyOnLoad(this);

        //Armazena uma função para executar quando uma nova fase começar
        SceneManager.sceneLoaded += loadConfigGame;
    }

    //Função chamada a cada troca de fase
    private void loadConfigGame(Scene scene, LoadSceneMode mode)
    {
        //Não aplica as configurações no menu
        if(scene.name != "MainMenu")
        {
            //Chama as funções de configuração
            attColors();
        }
        
    }

    //Usada no menu para salvar a configuração de cores do jogador
    public void setColorConfig(ColorConfig newColor, bool useColor)
    {
        this.useColor = useColor;
        this.configColor = newColor;
    }

    //Função que atualiza as cores dos objetos conforme configuração do jogador
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
