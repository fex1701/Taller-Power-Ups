using UnityEngine;
using UnityEngine.SceneManagement;

public class Menusystem : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Assets/_main/Scenes/Plataforma.unity");
    }
   
    public void salir()
    {
        Application.Quit();
    }
}
