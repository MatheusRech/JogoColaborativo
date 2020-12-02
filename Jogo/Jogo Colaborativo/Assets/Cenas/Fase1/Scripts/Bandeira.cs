using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandeira : MonoBehaviour
{

    private int players = 0;

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3.5f, gameObject.transform.position.z);

            players++;

            if (players == 2)
                SceneManager.LoadScene("Fase2");

        }
    }

    private void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 3.5f, gameObject.transform.position.z);
            players--;

        }
    }

}
