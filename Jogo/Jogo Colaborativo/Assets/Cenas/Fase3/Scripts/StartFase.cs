using System;
using System.Collections;
using UnityEngine;

public class StartFase : MonoBehaviour
{
    public bool find;

    void Start()
    {
        find = false;
        StartCoroutine(update());
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    IEnumerator update()
    {
        while (true)
        {
            if (find)
                break;

            yield return new WaitForSeconds(0.25f);

            try
            {
                GameObject.FindGameObjectWithTag("Player1").transform.position = new Vector3(-55f, 11.229f, 0f);
                GameObject.FindGameObjectWithTag("Player2").transform.position = new Vector3(-55f, -25.870f, 0f);
                find = true;
            }
            catch (Exception)
            {

            }
        }
        
    }
}
