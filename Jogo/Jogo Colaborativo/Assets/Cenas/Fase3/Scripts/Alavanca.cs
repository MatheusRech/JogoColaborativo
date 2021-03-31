using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour, Interacao
{
    public GameObject plataforma;
    public float Max;
    public float Min;

    private int mode = 0;
    private bool control = false;

    void Update()
    {
        switch (mode)
        {
            case 1:
                if(Max < plataforma.transform.position.y)
                {
                    plataforma.transform.position += new Vector3(0, 0.3f);
                }
                break;
            case -1:
                if (Min > plataforma.transform.position.y)
                {
                    plataforma.transform.position -= new Vector3(0, 0.3f);
                }
                break;
        }
    }

    public void interagir()
    {
        if (mode == 0 && control)
        {
            mode += 1;
            Quaternion target = Quaternion.Euler(0, 0, 15);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target, Time.deltaTime * 5);
        } 
        else if (mode == 0 && !control)
        {
            mode -= 1;
            Quaternion target = Quaternion.Euler(0, 0, -15);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target, Time.deltaTime * 5);
        } 
        else if (mode == 1)
        {
            mode -= 1;
            control = false;
            Quaternion target = Quaternion.Euler(0, 0, -15);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target, Time.deltaTime * 5);
        } 
        else if (mode == -1)
        {
            mode += 1;
            control = true;
            Quaternion target = Quaternion.Euler(0, 0, 15);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target, Time.deltaTime * 5);
        }

    }
}
