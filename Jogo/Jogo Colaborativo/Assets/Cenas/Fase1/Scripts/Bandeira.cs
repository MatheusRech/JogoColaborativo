using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandeira : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3.5f, gameObject.transform.position.z);

        }
    }

    private void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player1" || colisor.gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 3.5f, gameObject.transform.position.z);

        }
    }

}
