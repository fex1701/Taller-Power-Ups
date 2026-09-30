using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;

    public void Pausar()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }
}