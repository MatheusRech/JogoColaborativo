using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorConfig : MonoBehaviour
{
    private Color personagem;
    private Color background;
    private Color plataforma;
    private Color objetoInteracao;

    public ColorConfig(Color personagem, Color background, Color plataforma, Color objetoInteracao)
    {
        this.personagem = personagem;
        this.background = background;
        this.plataforma = plataforma;
        this.objetoInteracao = objetoInteracao;
    }

    void Start()
    {
        
    }

}
