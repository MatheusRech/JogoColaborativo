using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMorteiro : MonoBehaviour
{
    private GameObject cameraJogo;
    private cameraManager manager;
    private Morteiro morteiro;

    public void include(GameObject cameraJogo, cameraManager manager, Morteiro morteiro)
    {
        this.manager = manager;
        this.cameraJogo = cameraJogo;
        this.morteiro = morteiro;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.disabilitarCamera(false);
        cameraJogo.transform.parent = null;
        cameraJogo.transform.rotation = new Quaternion(0, 0, 0, 0);

        if(collision.transform.gameObject.name == "Alvo")
        {
            morteiro.acerto();
        }

        Destroy(gameObject);
        return;


    }
}
