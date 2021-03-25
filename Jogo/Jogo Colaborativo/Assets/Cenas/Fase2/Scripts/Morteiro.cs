using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script que controla um morteiro
public class Morteiro : MonoBehaviour
{
    //Prefab do projetil do morteiro
    public GameObject projetil;
    //Anglo maximo do morteiro
    public float maxAngle;
    //Objeto do canhao
    public GameObject canhao;
    //Botao que move para frente o angulo do canhão
    public GameObject BotaoFrente;
    //Botao que move para traz o angulo do canhão
    public GameObject BotaoTraz;
    //Camera
    public GameObject cameraJogo;
    //Script da camera
    public cameraManager manager;

    //ATENÇÃO NÃO MEXER POR NADA NESTAS VARIAVEIS :)
    //Variaveis que foram descobertas para melhor precisão do canhão
    //As variaveis foram encontradas após ser feita uma escala da força do morteiro

    //ForçaX vai de -25 a 25 e é a escala de 45º graus diminuida para 25
    private float forceX = 1;
    //ForçaY vai de 18 a 25 e é a escala da potencia do canhão, a força do canhão é escalonada porque o add force cria um vetor
    //Com as forças de X e Y, caso essa força seja fixa o morteiro com 45º teria uma força de disparo quadriplicada em relação aos outros angulos
    private float forceY = 25;
    //Anglo do canhao
    private float angle = 0;
    //Ultimo projetil
    private GameObject bola;

    void Update()
    {
        //Conta maluca pra colocar o morteiro na posição de tiro, caso alguem precise mecher aqui me contate que eu explico, e caso eu esta morto boa sorte em saber como isso aqui funciona :)
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

    //Função que dispara a bola e calcula o vetor do projetil, que é uma parabola
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

    //Função que é chamada pelo projetil após acertar o alvo
    public void acerto()
    {
        GameObject.Find("Alcapao").transform.position += new Vector3(0, 8);
    }


}
