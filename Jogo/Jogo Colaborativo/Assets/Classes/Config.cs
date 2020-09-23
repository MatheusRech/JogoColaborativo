using UnityEngine;
using System;

[Serializable]
public class Config
{
    [SerializeField]
    public Key paraFrente { get; private set; }
    [SerializeField]
    public Key paraTras { get; private set; }
    [SerializeField]
    public Key pular { get; private set; }

    [SerializeField]
    public float volumePrincipal { get; private set; }
    [SerializeField]
    public float volumeMusica { get; private set; }
    [SerializeField]
    public float volumeEfx { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void setVolumePrincipal(float volume)
    {
        this.volumePrincipal = volume;
    }

    public void setVolumeMusica(float volume)
    {
        this.volumeMusica = volume;
    }

    public void setVolumeEfx(float volume)
    {
        this.volumeEfx = volume;
    }

    public void setKeyFrente(Key key)
    {
        if (key.keySeted)
        {
            paraFrente = key;
        }
    }

    public void setKeyTras(Key key)
    {
        if (key.keySeted)
        {
            paraTras = key;
        }
    }

    public void setKeyPular(Key key)
    {
        if (key.keySeted)
        {
            pular = key;
        }
    }

    public static Config defaultConfig(int numberplayer)
    {
        Config defaultConfiguration = new Config();

        if(numberplayer == 1)
        {
            defaultConfiguration.setKeyFrente(new Key(KeyCode.D));
            defaultConfiguration.setKeyTras(new Key(KeyCode.A));
            defaultConfiguration.setKeyPular(new Key(KeyCode.W));
        }
        else
        {
            defaultConfiguration.setKeyFrente(new Key(KeyCode.Keypad6));
            defaultConfiguration.setKeyTras(new Key(KeyCode.Keypad4));
            defaultConfiguration.setKeyPular(new Key(KeyCode.Keypad8));
        }

        defaultConfiguration.setVolumePrincipal(100);
        defaultConfiguration.setVolumeMusica(100);
        defaultConfiguration.setVolumeEfx(100);

        return defaultConfiguration;
    }
}
