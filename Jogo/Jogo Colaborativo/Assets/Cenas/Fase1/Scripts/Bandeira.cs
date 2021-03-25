/*
 * 
 * Classe utilizada para monitorar o fim da fase
 * 
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandeira : MonoBehaviour
{
    // Nome da scene da proxima fase
    public string nextFase;
    //Variavel de controle dos jogadores
    private int players = 0;

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        //Quando um jogador entra na area da bandeira verifica se os dois jogadores estão dentro e passa para a proxima fase
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3.5f, gameObject.transform.position.z);

            players++;

            if (players == 2)
                SceneManager.LoadScene(nextFase);

        }
    }


    //Remove um jogador da variavel de controle quando sai da area da trigger
    private void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 3.5f, gameObject.transform.position.z);
            players--;

        }
    }

}
