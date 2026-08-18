using System;
using Unity.VisualScripting;
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
}
