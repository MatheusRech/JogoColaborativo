/*
 * 
 * Classe que salva as configurações do cor
 * 
 */

using UnityEngine;

public class ColorConfig
{
    //Cores que podem ser alteradas
    private Color personagem;
    private Color background;
    private Color plataforma;
    private Color objetoInteracao;

    //Cria nova configuração
    public ColorConfig(Color personagem, Color background, Color plataforma, Color objetoInteracao)
    {
        this.personagem = personagem;
        this.background = background;
        this.plataforma = plataforma;
        this.objetoInteracao = objetoInteracao;
    }

    //Devolve cores gravadas
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
