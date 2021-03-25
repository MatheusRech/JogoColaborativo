using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script da bola do morteiro

public class BolaMorteiro : MonoBehaviour
{
    //Armazena a camera da fase
    private GameObject cameraJogo;
    //Armazena o script da camera do jogo
    private cameraManager manager;
    //Armazena o script do morteiro
    private Morteiro morteiro;

    //salva as variaveis que vem do morteiro
    public void include(GameObject cameraJogo, cameraManager manager, Morteiro morteiro)
    {
        this.manager = manager;
        this.cameraJogo = cameraJogo;
        this.morteiro = morteiro;
    }

    // Quando a bola acerta algo, ela se destoi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Abilita novamente o script da camera
        manager.disabilitarCamera(false);
        //Coloca a camera como um objeto sem hierarquia
        cameraJogo.transform.parent = null;
        //Corrige a rotação da camera
        cameraJogo.transform.rotation = new Quaternion(0, 0, 0, 0);
        //Caso acerte o alvo envia para o morteiro que acertou o alvo
        if(collision.transform.gameObject.name == "Alvo")
        {
            morteiro.acerto();
        }
        //Destroi a bola
        Destroy(gameObject);
        return;


    }
}
