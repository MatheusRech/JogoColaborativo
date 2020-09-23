using UnityEngine;
using UnityEngine.SceneManagement;

public class alterScene : MonoBehaviour
{
    void Start()
    {
        
    }

    public void alter(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
