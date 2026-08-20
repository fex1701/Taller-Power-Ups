using UnityEngine;
using UnityEngine.UI;

public class IUManager : MonoBehaviour
{
    [SerializeField] private Image Contadordevida;

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
}