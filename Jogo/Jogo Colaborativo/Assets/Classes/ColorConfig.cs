using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorConfig
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

    public Color getPersonagem()
    {
        return this.personagem;
    }

    public Color getPlataforma()
    {
        return this.plataforma;
    }

    public Color getBackground()
    {
        return this.background;
    }

    public Color getObjetoInteracao()
    {
        return this.objetoInteracao;
    }

}
