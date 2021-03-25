using UnityEngine;

//Classe que é utilizada para armazenar as teclas

public class Key
{
    public KeyCode keyCode { get; private set; }
    public bool keySeted { get; private set; }

    public Key()
    {
        this.keySeted = false;
    }

    public Key(KeyCode key)
    {
        this.keyCode = key;
        this.keySeted = true;
    }

}
