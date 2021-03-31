using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0.3f,0);
    }
}
