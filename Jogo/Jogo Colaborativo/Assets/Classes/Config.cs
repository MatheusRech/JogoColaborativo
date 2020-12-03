using UnityEngine;
using System;
using System.IO;

public class Config
{

    public Key paraFrente { get; private set; }

    public Key paraTras { get; private set; }

    public Key pular { get; private set; }

    public Key interacao { get; private set; }

    public float volumePrincipal { get; private set; }

    public float volumeMusica { get; private set; }

    public float volumeEfx { get; private set; }

    public bool modoJoystick { get; private set; }

    public int joystickSelection { get; private set; }

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

    public void setModeJoystick(bool mode)
    {
        this.modoJoystick = mode;
    }

    public void setJoystick(int joystick)
    {
        this.joystickSelection = joystick;
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

    public void setKeyInteracao(Key key)
    {
        if (key.keySeted)
        {
            interacao = key;
        }
    }

    public static Config defaultConfig(int numberplayer)
    {
        Config defaultConfiguration = new Config();

        defaultConfiguration.setModeJoystick(false);

        if(numberplayer == 1)
        {
            defaultConfiguration.setKeyFrente(new Key(KeyCode.D));
            defaultConfiguration.setKeyTras(new Key(KeyCode.A));
            defaultConfiguration.setKeyPular(new Key(KeyCode.W));
            defaultConfiguration.setKeyInteracao(new Key(KeyCode.J));
            
        }
        else
        {
            defaultConfiguration.setKeyFrente(new Key(KeyCode.Keypad6));
            defaultConfiguration.setKeyTras(new Key(KeyCode.Keypad4));
            defaultConfiguration.setKeyPular(new Key(KeyCode.Keypad8));
            defaultConfiguration.setKeyInteracao(new Key(KeyCode.Keypad0));
        }

        defaultConfiguration.setVolumePrincipal(100);
        defaultConfiguration.setVolumeMusica(100);
        defaultConfiguration.setVolumeEfx(100);

        return defaultConfiguration;
    }

    public static Config loadConfig(int numberPlayer)
    {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JogoColaborativo\\Config" + numberPlayer.ToString() + ".txt";

        Debug.Log(path);


        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JogoColaborativo\\"))
        {
            Debug.Log("Criando");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JogoColaborativo\\");
        }

        try {
            Config config = new Config();

            string[] lines = System.IO.File.ReadAllLines(path);

            Key tecla = new Key();
            KeyCode key = new KeyCode();

            for (int x = 0; x < lines.Length; x++)
            {
                switch (x)
                {
                    case 0:
                        key = (KeyCode)int.Parse(lines[x]);
                        tecla = new Key(key);
                        config.setKeyFrente(tecla);
                        break;
                    case 1:
                        key = (KeyCode)int.Parse(lines[x]);
                        tecla = new Key(key);
                        config.setKeyTras(tecla);
                        break;
                    case 2:
                        key = (KeyCode)int.Parse(lines[x]);
                        tecla = new Key(key);
                        config.setKeyPular(tecla);
                        break;
                    case 3:
                        key = (KeyCode)int.Parse(lines[x]);
                        tecla = new Key(key);
                        config.setKeyInteracao(tecla);
                        break;
                    case 4:
                        config.setVolumePrincipal(float.Parse(lines[x]));
                        break;
                    case 5:
                        config.setVolumeMusica(float.Parse(lines[x]));
                        break;
                    case 6:
                        config.setVolumeEfx(float.Parse(lines[x]));
                        break;
                }
            }

            return config;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return defaultConfig(numberPlayer);
        }
        

    }

    public void saveConfig(int numberPlayer)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JogoColaborativo\\Config" + numberPlayer.ToString() + ".txt";

        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JogoColaborativo\\"))
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JogoColaborativo\\");
        }

        try
        {
            FileStream file = new FileStream(path, FileMode.Create);

            byte[] texto = System.Text.Encoding.UTF8.GetBytes(((int)paraFrente.keyCode).ToString() + "\n" + ((int)paraTras.keyCode).ToString() + "\n" + ((int)pular.keyCode).ToString() + "\n" + ((int)interacao.keyCode).ToString() + "\n" + volumePrincipal.ToString() + "\n" + volumeMusica.ToString() + "\n" + volumeEfx.ToString());

            file.Write(texto, 0, texto.Length);

            file.Close();
        }
        catch (Exception)
        {

        }
    }
}
