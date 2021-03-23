using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvoMorteiro : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<Morteiro>().acerto();
    }
}
