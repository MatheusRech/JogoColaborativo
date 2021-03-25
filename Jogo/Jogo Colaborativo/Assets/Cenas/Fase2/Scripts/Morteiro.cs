using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Morteiro : MonoBehaviour
{
    public GameObject projetil;
    public float maxAngle;
    public GameObject canhao;
    public GameObject BotaoFrente;
    public GameObject BotaoTraz;
    public GameObject cameraJogo;
    public cameraManager manager;

    private float forceX = 1;
    private float forceY = 25;
    private float angle = 0;
    private GameObject bola;

    void Update()
    {
        if (BotaoFrente.GetComponent<BotaoMorteiro>().press && ((canhao.transform.rotation.z * 100) - 6) >= maxAngle * -1)
        {
            angle -= 0.05f;
            Quaternion target = Quaternion.Euler(0, 0, angle);
            canhao.transform.rotation = Quaternion.Slerp(canhao.transform.rotation, target, Time.deltaTime * 5);

        }
        else if (BotaoTraz.GetComponent<BotaoMorteiro>().press && ((canhao.transform.rotation.z * 100) + 6) <= maxAngle)
        {
            angle += 0.05f;
            Quaternion target = Quaternion.Euler(0, 0, angle);
            canhao.transform.rotation = Quaternion.Slerp(canhao.transform.rotation, target, Time.deltaTime * 5);
        }
    }

    public void disparar()
    {
        manager.disabilitarCamera(true);

        if(bola != null)
        {
            cameraJogo.transform.parent = null;
            Destroy(bola);
        }

        forceX = (((canhao.transform.rotation.z * 100) - 6) * 0.388888f) * -1;
        forceY = (((canhao.transform.rotation.z * 100) - 6) * 0.155555f) + 18;

        if ((((canhao.transform.rotation.z * 100) - 6) * 0.155555f) < 0)
        {
            forceY = ((((canhao.transform.rotation.z * 100) - 6) * 0.155555f) * -1) + 18;
        }
        
        GameObject disparo = Instantiate(projetil);

        disparo.transform.position = canhao.transform.position + new Vector3(0,1,0);

        disparo.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);

        bola = disparo;

        cameraJogo.transform.parent = disparo.transform;
        cameraJogo.transform.position = disparo.transform.position - new Vector3(0,0,10);

        disparo.GetComponent<BolaMorteiro>().include(cameraJogo, manager, this);
    }

    public void acerto()
    {
        GameObject.Find("Alcapao").transform.position += new Vector3(0, 8);
    }


}
