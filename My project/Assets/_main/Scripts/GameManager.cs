using System;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int Life = 100;
    [SerializeField] private PlayerMovement Jugador;
    [SerializeField] private IUManager IUmanager;


    public void RestarVida(int _Damage)

    {
        if (Life > 0)

        {


            Life -= _Damage;
            IUmanager.Colorvida(Color.red);
            Debug.Log(" restar " + _Damage + " puntos de vida ");
            IUmanager.FillAmount_Colorvida(Life / 100f);

        }

        if (Life <= 0)
        {
            Destroy(Jugador.gameObject);
            Debug.Log("Se muriooo");
        }
        if (Life >= 80)
        {
            IUmanager.Colorvida(Color.green);
        }

        if (Life < 80)

        {
            IUmanager.Colorvida(Color.orange);

        }

        if (Life == 20)
        {

            IUmanager.Colorvida(Color.orange);
        }

        if (Life < 20)
        {
            IUmanager.Colorvida(Color.darkRed);
        }
    }


}