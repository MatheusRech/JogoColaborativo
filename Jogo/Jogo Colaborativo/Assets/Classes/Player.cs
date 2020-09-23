using System.IO;
using UnityEngine;
using System;
using System.Text;


public class Player : MonoBehaviour
{
    [SerializeField]
    public Config config;
    [SerializeField]
    public int numberPlayer;

    private Rigidbody2D rigidbody;
    private SpriteRenderer renderer;


    private bool frente;
    private bool tras;
    private bool ground;
    private Vector2 velocidade;

    void Start()
    {
        DontDestroyOnLoad(this);
        loadConfig();

        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();

        velocidade = new Vector2(0, 0);

        ground = false;
    }

    void Update()
    {
        velocidade = new Vector2(0, 0);

        if (Input.GetKeyDown(config.paraFrente.keyCode))
        {
            frente = true;
        }else if (Input.GetKeyUp(config.paraFrente.keyCode))
        {
            frente = false;
        }

        if (Input.GetKeyDown(config.paraTras.keyCode))
        {
            tras = true;
        }
        else if (Input.GetKeyUp(config.paraTras.keyCode))
        {
            tras = false;
        }

        if (frente)
        {
            velocidade.x = 1.7f;
            renderer.flipX = false;
        }
        else if (tras)
        {
            velocidade.x = -1.7f;
            renderer.flipX = true;
        }

        if(ground && Input.GetKeyUp(config.pular.keyCode))
        {
            velocidade.y = 280;
        }

        rigidbody.AddForce(velocidade);
    }

    public void setConfig(Config config)
    {
        this.config = config;
    }

    public void loadConfig()
    {
        string path = Application.dataPath + "/Config/";

        DirectoryInfo directory = new DirectoryInfo(path);

        if(directory.GetFiles().Length > 0)
        {
            foreach (FileInfo file in directory.GetFiles())
            {
                if(file.Name == "Config" + this.numberPlayer.ToString() + ".JSON")
                {
                    using (StreamReader sr = File.OpenText(file.FullName))
                    {
                        string json = "";
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            json += s;
                        }

                        Debug.Log(json);

                        this.config = JsonUtility.FromJson<Config>(json);

                        return;
                    }


                }

            }

            this.config = Config.defaultConfig(numberPlayer);

        }
        else
        {
            this.config = Config.defaultConfig(numberPlayer);
        }
    }

    public void saveConfig()
    {
        string fileName = Application.dataPath + "/Config/Config" + this.numberPlayer.ToString() + ".JSON";

        string json = JsonUtility.ToJson(config);

        try
        {    
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (StreamWriter sw = File.CreateText(fileName))
            {
                Debug.Log(json);

                sw.WriteLine(json);
            }

        }
        catch (Exception Ex)
        {
            Debug.LogError(Ex.ToString());
        }
    }

    private void OnCollisionEnter2D(Collision2D colidor)
    {
        if(colidor.gameObject.tag == "Plataforma" || colidor.gameObject.tag == "Botão")
        {
            ground = true;
        }
    }


    private void OnCollisionExit2D(Collision2D colidor)
    {
        if (colidor.gameObject.tag == "Plataforma" || colidor.gameObject.tag == "Botão")
        {
            ground = false;
        }
    }
}
