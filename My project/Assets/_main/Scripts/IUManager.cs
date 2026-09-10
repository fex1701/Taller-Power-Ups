using UnityEngine;
using UnityEngine.UI;

public class IUManager : MonoBehaviour
{
    [SerializeField] private Image Contadordevida;
    [SerializeField] private GameObject perdisteIU;
    [SerializeField] private GameObject[] imagenesGemas;

    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        Contadordevida.color = Color.cyan;
        Contadordevida.fillAmount = 1;
    }

    public void Colorvida(Color color)
    {
        Contadordevida.color = color;
    }

    public void FillAmount_Colorvida(float fillAmount)
    {
        Contadordevida.fillAmount = fillAmount;
    }

    public void ActualizarColorVida(int _life)
    {
        switch (_life)
        {
            case >= 80:
                Colorvida(Color.green);
                break;

            case < 20:
                Colorvida(Color.darkRed);
                break;

            case < 80:
                Colorvida(Color.orange);
                break;
        }
    }

    public void juegoterminado()
    {
       perdisteIU.SetActive(true);
    }


    public void MostrarGema(int numeroGema)
    {
        imagenesGemas[numeroGema].SetActive(true);
    }
}